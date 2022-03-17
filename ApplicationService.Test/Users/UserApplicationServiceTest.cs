using ApplicationService.Users;
using ApplicationService.Users.Ban;
using ApplicationService.Users.Commons;
using ApplicationService.Users.Delete;
using ApplicationService.Users.Login;
using ApplicationService.Users.Logout;
using DomainModel.BannedUsers;
using DomainModel.Users;
using EFInfrastructure.Persistence.BannedUsers;
using EFInfrastructure.Persistence.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Test.Users
{
    [TestClass]
    public class UserApplicationServiceTest : ApplicationServiceTestBase
    {
        private IUserRepository _userRepository;
        private IBannedUserRepository _bannedUserRepository;
        private IUserApplicationService _userApplicationService;
        private User admin;

        [TestInitialize]
        public void TestInitialize()
        {
            _userRepository = new EFUserRepository(DbContext);
            _bannedUserRepository = new EFBannedUserRepository(DbContext);
            _userApplicationService = new UserApplicationService(_userRepository, _bannedUserRepository);

            admin = new User("admin", "admin", "image", "oauthToken", "oauthTokenSecret", Role.Administrator);
            _userRepository.Create(admin);
        }

        [TestMethod]
        public void ログインしてログアウトする()
        {
            var loginCommand = new UserLoginCommand
            {
                Id = "id",
                Name = "名前",
                Image = "image",
                OauthToken = "oathToken",
                OauthTokenSecret = "oathTokenSecret"
            };
            _userApplicationService.Login(loginCommand);

            var user = _userRepository.Find("id");
            Assert.IsNotNull(user);
            Assert.AreEqual(user.Name, "名前");
            Assert.IsTrue(user.SessionId.Length > 1);

            var logoutCommand = new UserLogoutCommand
            {
                UserId = user.Id,
                SessionId = user.SessionId
            };
            _userApplicationService.Logout(logoutCommand);

            user = _userRepository.Find("id");

            Assert.IsTrue(user.SessionId.Length == 0);
        }

        [TestMethod]
        public void ログインしたユーザを削除する()
        {
            var loginCommand = new UserLoginCommand
            {
                Id = "id",
                Name = "名前",
                Image = "image",
                OauthToken = "oathToken",
                OauthTokenSecret = "oathTokenSecret"
            };
            _userApplicationService.Login(loginCommand);

            var command = new UserDeleteCommand
            {
                UserId = admin.Id,
                SessionId = admin.SessionId,
                TargetUserId = "id"
            };
            _userApplicationService.Delete(command);

            var user = _userRepository.Find("id");
            Assert.IsNull(user);
        }

        [TestMethod]
        public void ログインしたユーザを禁止ユーザにする()
        {
            var loginCommand = new UserLoginCommand
            {
                Id = "id",
                Name = "名前",
                Image = "image",
                OauthToken = "oathToken",
                OauthTokenSecret = "oathTokenSecret"
            };
            _userApplicationService.Login(loginCommand);

            var command = new UserBanCommand
            {
                UserId = admin.Id,
                SessionId = admin.SessionId,
                TargetUserId = "id"
            };
            _userApplicationService.Ban(command);

            var user = _userRepository.Find("id");
            Assert.IsNull(user);

            var bannedUsers = _bannedUserRepository.FindAll();
            Assert.AreEqual(1, bannedUsers.Count);
        }
    }
}
