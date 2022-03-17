using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Users.Logout
{
    public class UserLogoutCommand
    {
        public string UserId { get; init; }
        public string SessionId { get; init; }
    }
}
