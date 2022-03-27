using ApplicationService.Users.Exceptions;
using ApplicationService.Videos.Add;
using ApplicationService.Videos.Commons;
using ApplicationService.Videos.Exceptions;
using ApplicationService.Videos.Export;
using ApplicationService.Videos.Get;
using ApplicationService.Videos.GetAllIds;
using ApplicationService.Videos.GetInfo;
using ApplicationService.Videos.Remove;
using ApplicationService.Videos.Update;
using AutoMapper;
using DomainModel.Channels;
using DomainModel.EditingHistories;
using DomainModel.Users;
using DomainModel.Videos;
using DomainModel.Videos.Rules;
using DomainModel.Videos.Stages;
using DomainModel.Videos.Weapons;
using DomainModel.Videos.WeaponTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApplicationService.Videos
{
    public class VideoApplicationService : IVideoApplicationService
    {
        private readonly IVideoFactory _videoFactory;
        private readonly IVideoRepository _videoRepository;
        private readonly IChannelFactory _channelFactory;
        private readonly IChannelRepository _channelRepository;
        private readonly IUserRepository _userRepository;
        private readonly IEditingHistoryRepository _editingHistoryRepository; 
        private readonly IMapper _mapper;

        public VideoApplicationService(
            IVideoFactory videoFactory,
            IVideoRepository videoRepository,
            IChannelFactory channelFactory,
            IChannelRepository channelRepository,
            IUserRepository userRepository,
            IEditingHistoryRepository editingHistoryRepository)
        {
            _videoFactory = videoFactory;
            _videoRepository = videoRepository;
            _channelFactory = channelFactory;
            _channelRepository = channelRepository;
            _userRepository = userRepository;
            _editingHistoryRepository = editingHistoryRepository;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Video, VideoData>();
                cfg.CreateMap<VideoInfo, VideoInfoData>();
                cfg.CreateMap<Battle, BattleData>();
                cfg.CreateMap<Rule, RuleData>();
                cfg.CreateMap<Stage, StageData>();
                cfg.CreateMap<Weapon, WeaponData>();

                cfg.CreateMap<Video, VideoExportData>();
                cfg.CreateMap<Battle, BattleExportData>()
                    .ForMember(d => d.Rule, opt => opt.MapFrom(s => s.Rule.Id))
                    .ForMember(d => d.Stage, opt => opt.MapFrom(s => s.Stage.Id))
                    .ForMember(d => d.Weapon, opt => opt.MapFrom(s => s.Weapon.Id));

                cfg.CreateMap<BattleAddData, Battle>();
            });
            _mapper = config.CreateMapper();
        }

        public void Add(VideoAddCommand command)
        {
            var user = _userRepository.Find(command.UserId);
            if (user == null) throw new UserNotFoundException(command.UserId, "ユーザが見つかりませんでした。");

            if (!user.Auth(command.SessionId)) throw new UserIsNotAuthenticatedException(command.UserId, "ユーザが認証されませんでした。");

            if (!user.CanDo(Aggregate.Video, UseCase.Add)) throw new UserIsNotAuthorizedException(user.Role, Aggregate.Channel, UseCase.Add, "権限がありません。");

            // Battleドメインモデルを生成する
            var battles = command.Video.Battles.Select(x => _mapper.Map<Battle>(x));

            // Battleを秒数順に並び替える
            battles = battles.OrderBy(x => x.Seconds);

            // 動画情報生成
            var video = _videoFactory.Create(command.Video.Id, battles.ToList());

            // 必要ならチャンネルを追加
            if (!_videoRepository.ExistsChannel(video.VideoInfo.ChannelId))
            {
                // チャンネル情報生成
                var channel = _channelFactory.Create(video.VideoInfo.ChannelId);

                _channelRepository.Create(channel);
            }

            var existingVideo = _videoRepository.Find(command.Video.Id);

            _videoRepository.Delete(command.Video.Id);

            _videoRepository.Create(video);

            // 履歴に追加
            var operationType = (existingVideo == null) ? OperationType.Add : OperationType.Modify;
            var editingHistory = new EditingHistory(user.Id, operationType, ContentType.Video, video);
            _editingHistoryRepository.Create(editingHistory);
        }

        public void Remove(VideoRemoveCommand command)
        {
            var user = _userRepository.Find(command.UserId);
            if (user == null) throw new UserNotFoundException(command.UserId, "ユーザが見つかりませんでした。");

            if (!user.Auth(command.SessionId)) throw new UserIsNotAuthenticatedException(command.UserId, "ユーザが認証されませんでした。");

            if (!user.CanDo(Aggregate.Video, UseCase.Remove)) throw new UserIsNotAuthorizedException(user.Role, Aggregate.Channel, UseCase.Add, "権限がありません。");

            var existingVideo = _videoRepository.Find(command.VideoId);

            _videoRepository.Delete(command.VideoId);

            // 必要ならチャンネルを削除
            if (!_videoRepository.ExistsChannel(existingVideo.VideoInfo.ChannelId))
            {
                _channelRepository.Delete(existingVideo.VideoInfo.ChannelId);
            }

            // 履歴に追加
            var editingHistory = new EditingHistory(user.Id, OperationType.Remove, ContentType.Video, existingVideo);
            _editingHistoryRepository.Create(editingHistory);
        }

        public void Update(VideoUpdateCommand command)
        {
            // 動画情報の更新
            // YouTube APIから情報を取得して、動画データを再生成する
            // 再生数などを最新にしたい場合に利用する
            // 試合データはそのまま
            var user = _userRepository.Find(command.UserId);
            if (user == null) throw new UserNotFoundException(command.UserId, "ユーザが見つかりませんでした。");

            if (!user.Auth(command.SessionId)) throw new UserIsNotAuthenticatedException(command.UserId, "ユーザが認証されませんでした。");

            if (!user.CanDo(Aggregate.Video, UseCase.Change)) throw new UserIsNotAuthorizedException(user.Role, Aggregate.Channel, UseCase.Add, "権限がありません。");

            var video = _videoRepository.Find(command.VideoId);

            var updatedVideo = _videoFactory.Create(video.Id, video.Battles);

            _videoRepository.Delete(video.Id);

            _videoRepository.Create(updatedVideo);
        }

        public VideoGetResult Get(VideoGetCommand command)
        {
            var video = _videoRepository.Find(command.VideoId);
            if (video == null) throw new VideoNotFoundException(command.VideoId, "動画が見つかりませんでした。");

            var dto = _mapper.Map<VideoData>(video);
            var result = new VideoGetResult
            {
                Video = dto
            };
            return result;
        }

        public VideoGetInfoResult GetInfo(VideoGetInfoCommand command)
        {
            var videoInfo = _videoFactory.GetVideoInfo(command.VideoId);
            var dto = _mapper.Map<VideoInfoData>(videoInfo);
            var result = new VideoGetInfoResult
            {
                VideoInfo = dto
            };
            return result;
        }

        public VideoExportResult Export(VideoExportCommand command)
        {
            var user = _userRepository.Find(command.UserId);
            if (user == null) throw new UserNotFoundException(command.UserId, "ユーザが見つかりませんでした。");

            if (!user.Auth(command.SessionId)) throw new UserIsNotAuthenticatedException(command.UserId, "ユーザが認証されませんでした。");

            if (!user.CanDo(Aggregate.Video, UseCase.Export)) throw new UserIsNotAuthorizedException(user.Role, Aggregate.Video, UseCase.Export, "権限がありません。");

            var videos = _videoRepository.FindAll();
            var dto = videos.Select(x => _mapper.Map<VideoExportData>(x)).ToList();
            var result = new VideoExportResult
            {
                Videos = dto
            };
            return result;
        }

        public VideoGetAllIdsResult GetAllIds()
        {
            var videos = _videoRepository.FindAll();
            var dto = videos.Select(x => x.Id).ToList();
            var result = new VideoGetAllIdsResult
            {
                VideoIds = dto
            };
            return result;
        }
    }
}
