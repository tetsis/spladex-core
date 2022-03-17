using AutoMapper;
using DomainModel.BannedUsers;
using EFInfrastructure.Contexts;
using EFInfrastructure.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFInfrastructure.Persistence.BannedUsers
{
    public class EFBannedUserRepository : IBannedUserRepository
    {
        private readonly SBIDbContext _context;
        private readonly IMapper _mapper;

        public EFBannedUserRepository(
            SBIDbContext context)
        {
            _context = context;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BannedUserDataModel, BannedUser>()
                    .ReverseMap();
            });
            _mapper = config.CreateMapper();
        }

        public BannedUser Find(string id)
        {
            var dataModel = _context.BannedUsers.SingleOrDefault(x => x.Id == id);
            if (dataModel == null) return null;

            var bannedUser = _mapper.Map<BannedUser>(dataModel);
            return bannedUser;
        }

        public List<BannedUser> FindAll()
        {
            var bannedUsers = _context.BannedUsers.Select(x => _mapper.Map<BannedUser>(x)).ToList();
            return bannedUsers;
        }

        public void Create(BannedUser bannedUser)
        {
            var found = _context.BannedUsers.SingleOrDefault(x => x.Id == bannedUser.Id);
            if (found != null) return;

            var dataModel = _mapper.Map<BannedUserDataModel>(bannedUser);
            _context.Add(dataModel);
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            var found = _context.BannedUsers.SingleOrDefault(x => x.Id == id);
            if (found == null) return;

            _context.BannedUsers.Remove(found);
            _context.SaveChanges();
        }
    }
}
