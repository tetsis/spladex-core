using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.BannedUsers
{
    public interface IBannedUserRepository
    {
        public BannedUser Find(string id);
        public List<BannedUser> FindAll();
        public void Create(BannedUser bannedUser);
        public void Delete(string id);
    }
}
