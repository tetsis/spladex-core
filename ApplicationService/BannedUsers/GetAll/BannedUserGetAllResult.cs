using ApplicationService.BannedUsers.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.BannedUsers.GetAll
{
    public class BannedUserGetAllResult
    {
        public List<BannedUserData> BannedUsers { get; init; }
    }
}
