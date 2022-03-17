using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFInfrastructure.DataModels
{
    public class FavoriteDataModel
    {
        public string UserId { get; set; }
        public string VideoId { get; set; }
        public int BattleIndex { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
