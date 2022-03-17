using ApplicationService.Users.Auth;
using ApplicationService.Users.Ban;
using ApplicationService.Users.ChangeRole;
using ApplicationService.Users.Commons;
using ApplicationService.Users.Delete;
using ApplicationService.Users.Exceptions;
using ApplicationService.Users.Get;
using ApplicationService.Users.GetAll;
using ApplicationService.Users.Login;
using ApplicationService.Users.Logout;
using AutoMapper;
using DomainModel.BannedUsers;
using DomainModel.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Users
{
    public class UserApplicationService : IUserApplicationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IBannedUserRepository _bannedUserRepository;
        private readonly IMapper _mapper;

        public UserApplicationService(
            IUserRepository userRepository,
            IBannedUserRepository bannedUserRepository)
        {
            _userRepository = userRepository;
            _bannedUserRepository = bannedUserRepository;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserData>();
            });
            _mapper = config.CreateMapper();
        }

        public UserLoginResult Login(UserLoginCommand command)
        {
            // 禁止ユーザの場合はログインできない
            var bannedUser = _bannedUserRepository.Find(command.Id);
            if (bannedUser != null) throw new UserIsBannedUserException(command.Id, "禁止ユーザです。");

            var user = _userRepository.Find(command.Id);
            if (user == null)
            {
                // Create
                user = new User(
                    command.Id,
                    command.Name,
                    command.Image,
                    command.OauthToken,
                    command.OauthTokenSecret,
                    Role.Editor);  // 最初はEditor

                // 一人目のユーザはadministratorにする
                var count = _userRepository.GetCount();
                if (count == 0)
                {
                    user.ChangeRole(Role.Administrator);
                }

                _userRepository.Create(user);
            }
            else
            {
                // Update
                user.ChangeProperties(command.Name, command.Image);
                user.ChangeTokens(command.OauthToken, command.OauthTokenSecret);
                user.SetSessionId();

                _userRepository.Update(user);
            }

            var result = new UserLoginResult
            {
                SessionId = user.SessionId
            };
            return result;
        }

        public UserGetResult Get(UserGetCommand command)
        {
            var user = _userRepository.Find(command.UserId);
            if (user == null) return null;

            var dto = _mapper.Map<UserData>(user);
            var result = new UserGetResult
            {
                User = dto
            };
            return result;
        }

        public UserGetAllResult GetAll()
        {
            var users = _userRepository.FindAll();
            var dto = users.Select(x => _mapper.Map<UserData>(x)).ToList();
            var result = new UserGetAllResult
            {
                Users = dto
            };
            return result;
        }

        public void Logout(UserLogoutCommand command)
        {
            var user = _userRepository.Find(command.UserId);
            if (user == null) throw new UserNotFoundException(command.UserId, "ユーザが見つかりませんでした。");

            if (!user.Auth(command.SessionId)) throw new UserIsNotAuthenticatedException(command.UserId, "ユーザが認証されませんでした。");

            user.Logout();

            _userRepository.Update(user);

            return;
        }

        public UserAuthResult Auth(UserAuthCommand command)
        {
            var user = _userRepository.Find(command.UserId);
            if (user == null) return new UserAuthResult { Success = false };

            var success = user.Auth(command.SessionId);

            var result = new UserAuthResult
            {
                Success = success
            };
            return result;
        }

        public void Delete(UserDeleteCommand command)
        {
            var user = _userRepository.Find(command.UserId);
            if (user == null) throw new UserNotFoundException(command.UserId, "ユーザが見つかりませんでした。");

            if (!user.Auth(command.SessionId)) throw new UserIsNotAuthenticatedException(command.UserId, "ユーザが認証されませんでした。");

            if (!user.CanDo(Aggregate.User, UseCase.Remove)) throw new UserIsNotAuthorizedException(user.Role, Aggregate.User, UseCase.Remove, "権限がありません。");

            _userRepository.Delete(command.TargetUserId);

            return;
        }

        public void Ban(UserBanCommand command)
        {
            var user = _userRepository.Find(command.UserId);
            if (user == null) throw new UserNotFoundException(command.UserId, "ユーザが見つかりませんでした。");

            if (!user.Auth(command.SessionId)) throw new UserIsNotAuthenticatedException(command.UserId, "ユーザが認証されませんでした。");

            if (!user.CanDo(Aggregate.User, UseCase.Remove)) throw new UserIsNotAuthorizedException(user.Role, Aggregate.User, UseCase.Remove, "権限がありません。");

            var targetUser = _userRepository.Find(command.TargetUserId);
            _userRepository.Delete(command.TargetUserId);

            var bannedUser = new BannedUser(targetUser.Id, targetUser.Name, targetUser.Image);
            _bannedUserRepository.Create(bannedUser);

            return;
        }

        public void ChangeRole(UserChangeRoleCommand command)
        {
            var user = _userRepository.Find(command.UserId);
            if (user == null) throw new UserNotFoundException(command.UserId, "ユーザが見つかりませんでした。");

            if (!user.Auth(command.SessionId)) throw new UserIsNotAuthenticatedException(command.UserId, "ユーザが認証されませんでした。");

            if (!user.CanDo(Aggregate.User, UseCase.Change)) throw new UserIsNotAuthorizedException(user.Role, Aggregate.User, UseCase.Change, "権限がありません。");

            // 自分の役割は変更できない
            if (user.Id == command.TargetUserId) throw new UserCannotChangeOwnRoleException(user.Id, "自分の役割は変更できません。");

            var targetUser = _userRepository.Find(command.TargetUserId);
            Role role;
            Enum.TryParse(command.TargetRole, out role);
            targetUser.ChangeRole(role);
            _userRepository.Update(targetUser);

            return;
        }
    }
}
