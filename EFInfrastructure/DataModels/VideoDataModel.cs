using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFInfrastructure.DataModels
{
    public class VideoDataModel
    {
        public string Id { get; set; }
        public string ChannelId { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public DateTime PublishedAt { get; set; }
        public int ViewCount { get; set; }

        public List<BattleDataModel> Battles { get; set; }
    }
}
