using ApplicationService.Channels.Commons;
using ApplicationService.Channels.GetAll;
using ApplicationService.Channels.Update;
using ApplicationService.Users.Exceptions;
using AutoMapper;
using DomainModel.Channels;
using DomainModel.EditingHistories;
using DomainModel.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApplicationService.Channels
{
    public class ChannelApplicationService : IChannelApplicationService
    {
        private readonly IChannelFactory _channelFactory;
        private readonly IChannelRepository _channelRepository;
        private readonly IUserRepository _userRepository;
        private readonly IEditingHistoryRepository _editingHistoryRepository; 
        private readonly IMapper _mapper;

        public ChannelApplicationService(
            IChannelFactory channelFactory,
            IChannelRepository channelRepository,
            IUserRepository userRepository,
            IEditingHistoryRepository editingHistoryRepository)
        {
            _channelFactory = channelFactory;
            _channelRepository = channelRepository;
            _userRepository = userRepository;
            _editingHistoryRepository = editingHistoryRepository;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Channel, ChannelData>();
                cfg.CreateMap<ChannelInfo, ChannelInfoData>();
            });
            _mapper = config.CreateMapper();
        }

        public void Update(ChannelUpdateCommand command)
        {
            // チャンネル情報の更新
            // YouTube APIから情報を取得して、チャンネルデータを再生成する
            // チャンネル登録者数などを最新にしたい場合に利用する
            var user = _userRepository.Find(command.UserId);
            if (user == null) throw new UserNotFoundException(command.UserId, "ユーザが見つかりませんでした。");

            if (!user.Auth(command.SessionId)) throw new UserIsNotAuthenticatedException(command.UserId, "ユーザが認証されませんでした。");

            if (!user.CanDo(Aggregate.Channel, UseCase.Change)) throw new UserIsNotAuthorizedException(user.Role, Aggregate.Channel, UseCase.Add, "権限がありません。");

            var channel = _channelRepository.Find(command.ChannelId);

            var updatedChannel = _channelFactory.Create(channel.Id);

            _channelRepository.Delete(channel.Id);

            _channelRepository.Create(updatedChannel);
        }

        public ChannelGetAllResult GetAll()
        {
            var channels = _channelRepository.FindAll();
            var dto = channels.Select(x => _mapper.Map<ChannelData>(x)).ToList();
            var result = new ChannelGetAllResult
            {
                Channels = dto
            };
            return result;
        }
    }
}
