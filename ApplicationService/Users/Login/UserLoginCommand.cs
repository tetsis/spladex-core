using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Users.Login
{
    public class UserLoginCommand
    {
        public string Id { get; init; }
        public string Name { get; init; }
        public string Image { get; init; }
        public string OauthToken { get; init; }
        public string OauthTokenSecret { get; init; }
    }
}
