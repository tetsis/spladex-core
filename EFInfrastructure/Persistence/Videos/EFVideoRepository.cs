using AutoMapper;
using DomainModel.Videos;
using DomainModel.Videos.Rules;
using EFInfrastructure.Contexts;
using EFInfrastructure.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFInfrastructure.Persistence.Videos
{
    public class EFVideoRepository : IVideoRepository
    {
        private readonly SBIDbContext _context;
        private readonly IMapper _mapper;

        public EFVideoRepository(
            SBIDbContext context)
        {
            _context = context;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<VideoDataModel, Video>()
                    .ReverseMap()
                    .IncludeMembers(s => s.VideoInfo);
                cfg.CreateMap<VideoInfo, VideoDataModel>();
                cfg.CreateMap<BattleDataModel, Battle>()
                    .ReverseMap()
                    .ForMember(d => d.Rule, opt => opt.MapFrom(s => s.Rule.Id))
                    .ForMember(d => d.Stage, opt => opt.MapFrom(s => s.Stage.Id))
                    .ForMember(d => d.Weapon, opt => opt.MapFrom(s => s.Weapon.Id));
            });
            _mapper = config.CreateMapper();
        }

        public Video Find(string id)
        {
            var dataModel = _context.Videos.Include(x => x.Battles).SingleOrDefault(x => x.Id == id);
            if (dataModel == null) return null;

            var video = _mapper.Map<Video>(dataModel);
            return video;
        }

        public List<Video> FindAll()
        {
            var videos = _context.Videos.Include(x => x.Battles).Select(x => _mapper.Map<Video>(x)).ToList();
            return videos;
        }

        public void Create(Video video)
        {
            var found = _context.Videos.SingleOrDefault(x => x.Id == video.Id);
            if (found != null) return;

            var dataModel = _mapper.Map<VideoDataModel>(video);

            // インデックスをつける
            dataModel.Battles = dataModel.Battles.Select((x, index) => x with { Index = index }).ToList();

            _context.Add(dataModel);
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            var found = _context.Videos.Include(x => x.Battles).SingleOrDefault(x => x.Id == id);
            if (found != null)
            {
                found.Battles.ForEach(battle =>
                {
                    _context.Battles.Remove(battle);

                });
                _context.Videos.Remove(found);
            }
            _context.SaveChanges();
        }

        public bool ExistsChannel(string channelId)
        {
            var exists = _context.Videos.Where(x => x.ChannelId == channelId).Count() > 0;
            return exists;
        }
    }
}
