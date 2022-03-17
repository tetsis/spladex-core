using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Favorites
{
    public interface IFavoriteRepository
    {
        void Create(Favorite favorite);
        void Delete(Favorite favorite);
    }
}
