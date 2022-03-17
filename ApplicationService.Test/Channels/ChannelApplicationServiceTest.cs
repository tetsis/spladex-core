using ApplicationService.Channels;
using ApplicationService.Channels.Add;
using ApplicationService.Channels.Export;
using ApplicationService.Channels.Remove;
using ApplicationService.Test.Mocks;
using ApplicationService.Users.Exceptions;
using DomainModel.Channels;
using DomainModel.EditingHistories;
using DomainModel.Users;
using EFInfrastructure.Persistence.Channels;
using EFInfrastructure.Persistence.EditingHistories;
using EFInfrastructure.Persistence.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Test.Channels
{
    [TestClass]
    public class ChannelApplicationServiceTest : ApplicationServiceTestBase
    {
        private IChannelFactory _channelFactory;
        private IChannelRepository _channelRepository;
        private IUserRepository _userRepository;
        private IEditingHistoryRepository _editingHistoryRepository;
        private IChannelApplicationService _channelApplicationService;
        private User editor, maintainer, admin;

        [TestInitialize]
        public void TestInitialize()
        {
            _channelFactory = new MockChannelFactory();
            _channelRepository = new EFChannelRepository(DbContext);
            _userRepository = new EFUserRepository(DbContext);
            _editingHistoryRepository = new EFEditingHistoryRepository(DbContext);
            _channelApplicationService = new ChannelApplicationService(_channelFactory, _channelRepository, _userRepository, _editingHistoryRepository);

            editor = new User("editor", "editor", "image", "oauthToken", "oauthTokenSecret", Role.Editor);
            _userRepository.Create(editor);

            maintainer = new User("maintainer", "maintainer", "image", "oauthToken", "oauthTokenSecret", Role.Maintainer);
            _userRepository.Create(maintainer);

            admin = new User("admin", "admin", "image", "oauthToken", "oauthTokenSecret", Role.Administrator);
            _userRepository.Create(admin);

        }

        [TestMethod]
        public void チャンネルを追加する()
        {
            var command = new ChannelAddCommand
            {
                UserId = admin.Id,
                SessionId = admin.SessionId,
                ChannelId = "channelId"
            };
            _channelApplicationService.Add(command);

            var channel = _channelRepository.Find("channelId");

            Assert.IsNotNull(channel);

            var editingHistory = _editingHistoryRepository.FindRange(0, 10);
            Assert.AreEqual(1, editingHistory.Count);
        }

        [TestMethod]
        public void チャンネルを削除する()
        {
            var channel = _channelFactory.Create("aaa");
            _channelRepository.Create(channel);

            var command = new ChannelRemoveCommand
            {
                UserId = admin.Id,
                SessionId = admin.SessionId,
                ChannelId = "aaa"
            };
            _channelApplicationService.Remove(command);

            var removedChannel = _channelRepository.Find("aaa");

            Assert.IsNull(removedChannel);
        }

        [TestMethod]
        public void 認証に失敗するとチャンネル削除できない()
        {
            bool exceptionOccured = false;
            try
            {
                var command = new ChannelRemoveCommand
                {
                    UserId = admin.Id,
                    SessionId = "aaa",
                    ChannelId = "aaa"
                };
                _channelApplicationService.Remove(command);
            }
            catch (UserIsNotAuthenticatedException)
            {
                exceptionOccured = true;
            }

            Assert.IsTrue(exceptionOccured);
        }

        [TestMethod]
        public void エディターはチャンネル削除できない()
        {
            bool exceptionOccured = false;
            try
            {
                var command = new ChannelRemoveCommand
                {
                    UserId = editor.Id,
                    SessionId = editor.SessionId,
                    ChannelId = "aaa"
                };
                _channelApplicationService.Remove(command);
            }
            catch (UserIsNotAuthorizedException)
            {
                exceptionOccured = true;
            }

            Assert.IsTrue(exceptionOccured);
        }

        [TestMethod]
        public void エクスポートする()
        {
            // たくさん登録する
            for (int i = 0; i < 100; i++)
            {
                var addCommand = new ChannelAddCommand
                {
                    UserId = admin.Id,
                    SessionId = admin.SessionId,
                    ChannelId = $"channelId{i}"
                };
                _channelApplicationService.Add(addCommand);

            }

            // エクスポートする
            var command = new ChannelExportCommand
            {
                UserId = admin.Id,
                SessionId = admin.SessionId,
            };
            var result = _channelApplicationService.Export(command);

            Assert.AreEqual(100, result.Channels.Count);
            Assert.AreEqual("channelId0", result.Channels[0].Id);
        }
    }
}
