using ApplicationService.Users.Auth;
using ApplicationService.Users.Ban;
using ApplicationService.Users.ChangeRole;
using ApplicationService.Users.Commons;
using ApplicationService.Users.Delete;
using ApplicationService.Users.Get;
using ApplicationService.Users.GetAll;
using ApplicationService.Users.Login;
using ApplicationService.Users.Logout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Users
{
    public interface IUserApplicationService
    {
        UserLoginResult Login(UserLoginCommand command);
        UserGetResult Get(UserGetCommand command);
        UserGetAllResult GetAll();
        void Logout(UserLogoutCommand command);
        UserAuthResult Auth(UserAuthCommand command);
        void Delete(UserDeleteCommand command);

        /// <summary>
        /// 削除した後に禁止ユーザにします
        /// </summary>
        /// <param name="command"></param>
        void Ban(UserBanCommand command);

        void ChangeRole(UserChangeRoleCommand command);
    }
}
