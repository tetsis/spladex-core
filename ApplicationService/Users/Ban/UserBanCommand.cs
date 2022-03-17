using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Users.Ban
{
    public class UserBanCommand
    {
        public string UserId { get; init; }
        public string SessionId { get; init; }
        public string TargetUserId { get; init; }
    }
}
