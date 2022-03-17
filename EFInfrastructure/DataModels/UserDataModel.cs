using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFInfrastructure.DataModels
{
    public class UserDataModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Image { get;set; }
        public string OauthToken { get; set; }
        public string OauthTokenSecret { get; set; }
        public string SessionId { get; set; }
        public string Role { get; private set; }
    }
}
