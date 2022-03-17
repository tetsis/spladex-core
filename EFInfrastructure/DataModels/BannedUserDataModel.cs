using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFInfrastructure.DataModels
{
    public class BannedUserDataModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Image { get;set; }
        public DateTime CreateTime { get; set; }
    }
}
