using AutoMapper;
using DomainModel.Users;
using EFInfrastructure.Contexts;
using EFInfrastructure.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFInfrastructure.Persistence.Users
{
    public class EFUserRepository : IUserRepository
    {
        private readonly SBIDbContext _context;
        private readonly IMapper _mapper;

        public EFUserRepository(
            SBIDbContext context)
        {
            _context = context;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDataModel, User>()
                    .ReverseMap();
            });
            _mapper = config.CreateMapper();
        }

        public User Find(string id)
        {
            var dataModel = _context.Users.SingleOrDefault(x => x.Id == id);
            if (dataModel == null) return null;

            var user = _mapper.Map<User>(dataModel);
            return user;
        }

        public List<User> FindAll()
        {
            var users = _context.Users.Select(x => _mapper.Map<User>(x)).ToList();
            return users;
        }

        public int GetCount()
        {
            int count = _context.Users.Count();
            return count;
        }

        public void Create(User user)
        {
            var found = _context.Users.SingleOrDefault(x => x.Id == user.Id);
            if (found != null) return;

            var dataModel = _mapper.Map<UserDataModel>(user);
            _context.Add(dataModel);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            var found = _context.Users.SingleOrDefault(x => x.Id == user.Id);
            if (found == null) return;

            _mapper.Map(user, found);
            _context.Update(found);
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            var found = _context.Users.SingleOrDefault(x => x.Id == id);
            if (found == null) return;

            _context.Users.Remove(found);
            _context.SaveChanges();
        }
    }
}
