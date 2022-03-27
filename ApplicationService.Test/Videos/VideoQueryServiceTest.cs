using ApplicationService.Videos;
using ApplicationService.Videos.Search;
using DomainModel.Channels;
using DomainModel.Favorites;
using DomainModel.Users;
using DomainModel.Videos;
using DomainModel.Videos.Rules;
using DomainModel.Videos.Stages;
using DomainModel.Videos.Weapons;
using EFInfrastructure.DataModels;
using EFInfrastructure.Persistence.Channels;
using EFInfrastructure.Persistence.Favorites;
using EFInfrastructure.Persistence.Users;
using EFInfrastructure.Persistence.Videos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Test.Videos
{
    [TestClass]
    public class VideoQueryServiceTest : ApplicationServiceTestBase
    {
        private IVideoQueryService _videoQueryService;
        private IUserRepository _userRepository;
        private IFavoriteRepository _favoriteRepository;
        private IChannelRepository _channelRepository;
        private IVideoRepository _videoRepository;
        private User user1, user2;
        private Channel channel;
        private Video video;
        private Favorite favorite1, favorite2;

        [TestInitialize]
        public void TestInitialize()
        {
            _videoQueryService = new EFVideoQueryService(DbContext);
            _userRepository = new EFUserRepository(DbContext);
            _favoriteRepository = new EFFavoriteRepository(DbContext);
            _channelRepository = new EFChannelRepository(DbContext);
            _videoRepository = new EFVideoRepository(DbContext);

            user1 = new User("user1", "user1", "image", "", "", Role.Viewer);
            _userRepository.Create(user1);
            user2 = new User("user2", "user2", "image", "", "", Role.Viewer);
            _userRepository.Create(user2);

            channel = new Channel("id", new ChannelInfo("name", "thumbnail", 1));
            _channelRepository.Create(channel);

            video = new Video("id",
                new VideoInfo("id", "title", "thumbnail", DateTime.Now, 1),
                new List<Battle>
                {
                    new Battle(0, Rules.GetById(RuleId.SplatZones), Stages.GetById(StageId.AnchoVGames), Weapons.GetById(WeaponId.AerosprayMG), 2000),
                    new Battle(10, Rules.GetById(RuleId.ClamBlitz), Stages.GetById(StageId.AnchoVGames), Weapons.GetById(WeaponId.AerosprayMG), 2000),
                }
            );
            _videoRepository.Create(video);

            favorite1 = new Favorite(user1.Id, video.Id, 0);
            _favoriteRepository.Create(favorite1);
            favorite2 = new Favorite(user2.Id, video.Id, 1);
            _favoriteRepository.Create(favorite2);
        }

        [TestMethod]
        public void 一覧を取得できる()
        {
            var command = new VideoSearchCommand
            {
            };
            var result = _videoQueryService.Search(command);

            Assert.AreEqual(2, result.Battles.Count);
        }

        [TestMethod]
        public void お気に入り情報が取得できる()
        {
            var command = new VideoSearchCommand
            {
                UserId = user1.Id
            };
            var result = _videoQueryService.Search(command);

            var favoriteOne = result.Battles.Where(x => x.IsFavorite).ToList();
            Assert.AreEqual(1, favoriteOne.Count);
            Assert.AreEqual("ガチエリア", favoriteOne[0].RuleName);
        }
    }
}
