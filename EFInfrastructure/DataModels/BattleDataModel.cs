using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFInfrastructure.DataModels
{
    public record BattleDataModel
    {
        public string VideoId { get; set; }
        public int Index { get; set; }
        public int Seconds { get; set; }
        public string Rule { get; set; }
        public string Stage { get; set; }
        public string Weapon { get; set; }
        public int RoomPower { get; set; }

        public VideoDataModel Video { get; set; }
    }
}
