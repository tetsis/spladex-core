using ApplicationService.Videos.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Videos.Export
{
    public class VideoExportData
    {
        public string Id { get; init; }
        public List<BattleData> Battles { get; init; }
    }
}
