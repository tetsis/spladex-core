using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Videos.Add
{
    public class VideoAddData
    {
        public string Id { get; init; }
        public List<BattleAddData> Battles { get; init; }
    }
}
