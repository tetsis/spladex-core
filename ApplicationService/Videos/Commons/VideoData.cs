using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Videos.Commons
{
    public class VideoData
    {
        public string Id { get; init; }
        public VideoInfoData VideoInfo { get; init; }
        public List<BattleData> Battles { get; init; }
    }
}
