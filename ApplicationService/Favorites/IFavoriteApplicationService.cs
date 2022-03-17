using ApplicationService.Favorites.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Favorites
{
    public interface IFavoriteApplicationService
    {
        void Add(FavoriteCommand command);
        void Remove(FavoriteCommand command);
    }
}
