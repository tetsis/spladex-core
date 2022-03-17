using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Videos.Commons
{
    public class VideoInfoData
    {
        public string ChannelId { get; init; }
        public string Title { get; init; }
        public string Thumbnail { get; init; }
        public DateTime PublishedAt { get; init; }
        public int ViewCount { get; init; }
    }
}
