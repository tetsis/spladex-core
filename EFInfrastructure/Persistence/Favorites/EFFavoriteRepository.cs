using AutoMapper;
using DomainModel.Favorites;
using EFInfrastructure.Contexts;
using EFInfrastructure.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFInfrastructure.Persistence.Favorites
{
    public class EFFavoriteRepository : IFavoriteRepository
    {
        private readonly SBIDbContext _context;
        private readonly IMapper _mapper;

        public EFFavoriteRepository(
            SBIDbContext context)
        {
            _context = context;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FavoriteDataModel, Favorite>()
                    .ReverseMap();
            });
            _mapper = config.CreateMapper();
        }

        public void Create(Favorite favorite)
        {
            var found = _context.Favorites.SingleOrDefault(x => (x.UserId == favorite.UserId && x.VideoId == favorite.VideoId && x.BattleIndex == favorite.BattleIndex));
            if (found != null) return;

            var dataModel = _mapper.Map<FavoriteDataModel>(favorite);
            _context.Add(dataModel);
            _context.SaveChanges();
        }

        public void Delete(Favorite favorite)
        {
            var found = _context.Favorites.SingleOrDefault(x => (x.UserId == favorite.UserId && x.VideoId == favorite.VideoId && x.BattleIndex == favorite.BattleIndex));
            if (found == null) return;

            _context.Favorites.Remove(found);
            _context.SaveChanges();
        }
    }
}
