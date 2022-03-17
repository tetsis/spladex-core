using ApplicationService.Favorites.Commons;
using ApplicationService.Users.Exceptions;
using DomainModel.Favorites;
using DomainModel.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Favorites
{
    public class FavoriteApplicationService : IFavoriteApplicationService
    {
        private readonly IFavoriteRepository _favoriteRepository;
        private readonly IUserRepository _userRepository;

        public FavoriteApplicationService(
            IFavoriteRepository favoriteRepository,
            IUserRepository userRepository)
        {
            _favoriteRepository = favoriteRepository;
            _userRepository = userRepository;
        }

        public void Add(FavoriteCommand command)
        {
            var user = _userRepository.Find(command.UserId);
            if (user == null) throw new UserNotFoundException(command.UserId, "ユーザが見つかりませんでした。");

            if (!user.Auth(command.SessionId)) throw new UserIsNotAuthenticatedException(command.UserId, "ユーザが認証されませんでした。");

            var favorite = new Favorite(command.UserId, command.VideoId, command.BattleIndex);
            _favoriteRepository.Create(favorite);
        }

        public void Remove(FavoriteCommand command)
        {
            var user = _userRepository.Find(command.UserId);
            if (user == null) throw new UserNotFoundException(command.UserId, "ユーザが見つかりませんでした。");

            if (!user.Auth(command.SessionId)) throw new UserIsNotAuthenticatedException(command.UserId, "ユーザが認証されませんでした。");

            var favorite = new Favorite(command.UserId, command.VideoId, command.BattleIndex);
            _favoriteRepository.Delete(favorite);
        }
    }
}
