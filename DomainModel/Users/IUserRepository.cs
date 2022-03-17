using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Users
{
    public interface IUserRepository
    {
        User Find(string id);
        List<User> FindAll();
        int GetCount();
        void Create(User user);
        void Update(User user);
        void Delete(string id);
    }
}
