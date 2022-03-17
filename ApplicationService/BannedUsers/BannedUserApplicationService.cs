using ApplicationService.BannedUsers.Commons;
using ApplicationService.BannedUsers.Delete;
using ApplicationService.BannedUsers.GetAll;
using ApplicationService.Users.Exceptions;
using AutoMapper;
using DomainModel.BannedUsers;
using DomainModel.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.BannedUsers
{
    public class BannedUserApplicationService : IBannedUserApplicationService
    {
        private readonly IBannedUserRepository _bannedUserRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public BannedUserApplicationService(
            IBannedUserRepository bannedUserRepository,
            IUserRepository userRepository)
        {
            _bannedUserRepository = bannedUserRepository;
            _userRepository = userRepository;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BannedUser, BannedUserData>();
            });
            _mapper = config.CreateMapper();
        }

        public BannedUserGetAllResult GetAll(BannedUserGetAllCommand command)
        {
            var user = _userRepository.Find(command.UserId);
            if (user == null) throw new UserNotFoundException(command.UserId, "ユーザが見つかりませんでした。");

            if (!user.Auth(command.SessionId)) throw new UserIsNotAuthenticatedException(command.UserId, "ユーザが認証されませんでした。");

            if (!user.CanDo(Aggregate.BannedUser, UseCase.Get)) throw new UserIsNotAuthorizedException(user.Role, Aggregate.BannedUser, UseCase.Get, "権限がありません。");

            var bannedUsers = _bannedUserRepository.FindAll();
            var dto = bannedUsers.Select(x => _mapper.Map<BannedUserData>(x)).ToList();
            var result = new BannedUserGetAllResult
            {
                BannedUsers = dto
            };
            return result;
        }

        public void Delete(BannedUserDeleteCommand command)
        {
            var user = _userRepository.Find(command.UserId);
            if (user == null) throw new UserNotFoundException(command.UserId, "ユーザが見つかりませんでした。");

            if (!user.Auth(command.SessionId)) throw new UserIsNotAuthenticatedException(command.UserId, "ユーザが認証されませんでした。");

            if (!user.CanDo(Aggregate.BannedUser, UseCase.Remove)) throw new UserIsNotAuthorizedException(user.Role, Aggregate.BannedUser, UseCase.Remove, "権限がありません。");

            _bannedUserRepository.Delete(command.TargetUserId);
        }
    }
}
