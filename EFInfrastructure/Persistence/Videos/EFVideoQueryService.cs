using ApplicationService.Videos;
using ApplicationService.Videos.Commons;
using ApplicationService.Videos.GetRange;
using ApplicationService.Videos.Search;
using AutoMapper;
using DomainModel.Videos;
using DomainModel.Videos.Rules;
using DomainModel.Videos.Stages;
using DomainModel.Videos.Weapons;
using EFInfrastructure.Contexts;
using EFInfrastructure.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFInfrastructure.Persistence.Videos
{
    public class EFVideoQueryService : IVideoQueryService
    {
        private readonly SBIDbContext _context;
        private readonly IMapper _mapper;
        private readonly int _limit = 9;

        public EFVideoQueryService(
            SBIDbContext context)
        {
            _context = context;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<VideoDataModel, Video>();
                cfg.CreateMap<BattleDataModel, Battle>();
                cfg.CreateMap<Video, VideoData>();
                cfg.CreateMap<VideoInfo, VideoInfoData>();
                cfg.CreateMap<Battle, BattleData>()
                    .ForMember(d => d.Rule, opt => opt.MapFrom(s => s.Rule.Id))
                    .ForMember(d => d.Stage, opt => opt.MapFrom(s => s.Stage.Id))
                    .ForMember(d => d.Weapon, opt => opt.MapFrom(s => s.Weapon.Id));
            });
            _mapper = config.CreateMapper();
        }

        public VideoSearchResult Search(VideoSearchCommand command)
        {
            // "all"はnullに変更
            string? channel = (String.Compare(command.Channel, "all", true) == 0) ? null : command.Channel; 
            string? rule = (String.Compare(command.Rule, "all", true) == 0) ? null : command.Rule; 
            string? stage = (String.Compare(command.Stage, "all", true) == 0) ? null : command.Stage; 
            string? weapon = (String.Compare(command.Weapon, "all", true) == 0) ? null : command.Weapon;

            var filteredItems = from Battle in _context.Battles
                                join Video in _context.Videos on Battle.VideoId equals Video.Id
                                join Channel in _context.Channels on Video.ChannelId equals Channel.Id
                                from Favorite in _context.Favorites.Where(x => x.UserId == command.UserId && x.VideoId == Battle.VideoId && x.BattleIndex == Battle.Index).DefaultIfEmpty()
                                select new
                                {
                                    Battle,
                                    Video,
                                    Channel,
                                    Favorite
                                };

            // チャンネルの指定があれば抜き出す
            if (channel != null)
            {
                filteredItems = filteredItems.Where(x => x.Video.ChannelId == channel);
            }

            // ルールの指定があれば抜き出す
            if (rule != null)
            {
                filteredItems = filteredItems.Where(x => x.Battle.Rule == rule);
            }

            // ステージの指定があれば抜き出す
            if (stage != null)
            {
                filteredItems = filteredItems.Where(x => x.Battle.Stage == stage);
            }

            // ブキの指定があれば抜き出す
            if (weapon != null)
            {
                filteredItems = filteredItems.Where(x => x.Battle.Weapon == weapon);
            }

            // 部屋パワーの指定があれば抜き出す
            if (command.MinRoomPower.HasValue) {
                filteredItems = filteredItems.Where(x => x.Battle.RoomPower >= command.MinRoomPower);
            }
            if (command.MaxRoomPower.HasValue)
            {
                filteredItems = filteredItems.Where(x => x.Battle.RoomPower <= command.MaxRoomPower);
            }

            // 並び替え
            if (command.Sort == Sort.PublishedAt.ToString())
            {
                filteredItems = filteredItems.OrderByDescending(x => x.Video.PublishedAt);
            }
            else if (command.Sort == Sort.ViewCount.ToString())
            {
                filteredItems = filteredItems.OrderByDescending(x => x.Video.ViewCount);
            }
            else
            {
                // デフォルトは投稿日で並び替える
                filteredItems = filteredItems.OrderByDescending(x => x.Video.PublishedAt);
            }

            // 件数
            int resultNumber = filteredItems.Count();
            int pageNumber = (int)Math.Ceiling((double)resultNumber / _limit);

            // ページで抜き出し
            var page = (command.Page > 0) ? command.Page : 1;
            filteredItems = filteredItems.Skip((page - 1) * _limit).Take(_limit);

            var battles = filteredItems.Select(x => new BattleDataForQuery
            {
                ChannelName = x.Channel.Name,
                VideoId = x.Video.Id,
                PublishedAt = x.Video.PublishedAt,
                Thumbnail = x.Video.Thumbnail,
                ViewCount = x.Video.ViewCount,
                BattleIndex = x.Battle.Index,
                RuleName = Rules.GetById(x.Battle.Rule).Name,
                StageName = Stages.GetById(x.Battle.Stage).Name,
                WeaponName = Weapons.GetById(x.Battle.Weapon).Name,
                RoomPower = x.Battle.RoomPower,
                Url = $"https://www.youtube.com/embed/{x.Video.Id}?start={x.Battle.Seconds}",
                IsFavorite = x.Favorite != null
            }).ToList();

            var result = new VideoSearchResult
            {
                Battles = battles,
                PageNumber = pageNumber,
                ResultNumber = resultNumber
            };
            return result;
        }

        public VideoGetRangeResult GetRange(VideoGetRangeCommand command)
        {
            var videos = _context.Videos.Include(x => x.Battles)
                                        .Where(x => x.PublishedAt >= command.PublishedFrom)
                                        .Where(x => x.ChannelId == command.Channel)
                                        .Select(x => _mapper.Map<Video>(x));

            var dto = videos.Select(x => _mapper.Map<VideoData>(x)).ToList();
            var result = new VideoGetRangeResult
            {
                Videos = dto
            };
            return result;
        }
    }
}
