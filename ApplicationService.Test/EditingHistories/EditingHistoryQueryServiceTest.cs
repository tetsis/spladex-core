using ApplicationService.EditingHistories;
using ApplicationService.EditingHistories.GetRange;
using ApplicationService.Test.Mocks;
using ApplicationService.Videos;
using ApplicationService.Videos.Add;
using ApplicationService.Videos.Commons;
using DomainModel.Channels;
using DomainModel.EditingHistories;
using DomainModel.Users;
using DomainModel.Videos;
using DomainModel.Videos.Rules;
using DomainModel.Videos.Stages;
using DomainModel.Videos.Weapons;
using EFInfrastructure.Persistence.Channels;
using EFInfrastructure.Persistence.EditingHistories;
using EFInfrastructure.Persistence.Users;
using EFInfrastructure.Persistence.Videos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Test.EditingHistories
{
    [TestClass]
    public class EditingHistoryQueryServiceTest : ApplicationServiceTestBase
    {
        private IEditingHistoryQueryService _editingHistoryQueryService;

        private IVideoFactory _videoFactory;
        private IVideoRepository _videoRepository;
        private IChannelFactory _channelFactory;
        private IChannelRepository _channelRepository;
        private IUserRepository _userRepository;
        private IEditingHistoryRepository _editingHistoryRepository;
        private IVideoApplicationService _videoApplicationService;
        private User user;

        [TestInitialize]
        public void TestInitialize()
        {
            _editingHistoryQueryService = new EFEditingHistoryQueryService(DbContext);

            _videoFactory = new MockVideoFactory();
            _videoRepository = new EFVideoRepository(DbContext);
            _channelFactory = new MockChannelFactory();
            _channelRepository = new EFChannelRepository(DbContext);
            _userRepository = new EFUserRepository(DbContext);
            _editingHistoryRepository = new EFEditingHistoryRepository(DbContext);
            _videoApplicationService = new VideoApplicationService(_videoFactory, _videoRepository, _channelFactory, _channelRepository, _userRepository, _editingHistoryRepository);

            user = new User("userId", "user", "", "", "", Role.Editor);
            _userRepository.Create(user);

            // 動画を追加
            var command = new VideoAddCommand
            {
                UserId = user.Id,
                SessionId = user.SessionId,
                VideoId = "videoId",
                Battles = new List<BattleData>
                {
                    new BattleData {
                        Seconds = 0,
                        Rule = Rules.GetAll()[0].Id.ToString(),
                        Stage = Stages.GetAll()[0].Id.ToString(),
                        Weapon = Weapons.GetAll()[0].Id.ToString()
                    }
                }
            };
            _videoApplicationService.Add(command);
        }

        [TestMethod]
        public void 履歴を取得する()
        {
            var command = new EditingHistoryGetRangeCommand { Page = 1 };
            var histories = _editingHistoryQueryService.GetRange(command).EditingHistories;

            Assert.AreEqual(1, histories.Count);
            Assert.AreEqual("Video", histories[0].ContentType);
        }
    }
}
