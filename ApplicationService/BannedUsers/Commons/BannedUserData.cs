using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.BannedUsers.Commons
{
    public class BannedUserData
    {
        public string Id { get; init; }
        public string Name { get; init; }
        public string Image { get; init; }
        public DateTime CreateTime { get; init; }
    }
}
