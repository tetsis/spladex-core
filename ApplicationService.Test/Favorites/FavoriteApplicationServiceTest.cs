using ApplicationService.Favorites;
using ApplicationService.Favorites.Commons;
using DomainModel.Favorites;
using DomainModel.Users;
using EFInfrastructure.Persistence.Favorites;
using EFInfrastructure.Persistence.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Test.Favorites
{
    [TestClass]
    public class FavoriteApplicationServiceTest : ApplicationServiceTestBase
    {
        private IFavoriteRepository _favoriteRepository;
        private IUserRepository _userRepository;
        private IFavoriteApplicationService _favoriteApplicationService;
        private User user;

        [TestInitialize]
        public void TestInitialize()
        {
            _favoriteRepository = new EFFavoriteRepository(DbContext);
            _userRepository = new EFUserRepository(DbContext);
            _favoriteApplicationService = new FavoriteApplicationService(_favoriteRepository, _userRepository);

            user = new User("id", "user", "image", "oauthToken", "oauthTokenSecret", Role.Viewer);
            _userRepository.Create(user);
        }

        [TestMethod]
        public void お気に入りを追加して削除する()
        {
            var command = new FavoriteCommand
            {
                UserId = user.Id,
                SessionId = user.SessionId,
                VideoId = "videoId",
                BattleIndex = 0
            };
            _favoriteApplicationService.Add(command);

            var favorite = DbContext.Favorites.FirstOrDefault();
            Assert.IsNotNull(favorite);

            _favoriteApplicationService.Remove(command);

            favorite = DbContext.Favorites.FirstOrDefault();
            Assert.IsNull(favorite);
        }
    }
}
