using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Videos
{
    public class VideoInfo
    {
        public VideoInfo(
            string channelId,
            string title,
            string thumbnail,
            DateTime publishedAt,
            int viewCount)
        {
            ChannelId = channelId;
            Title = title;
            Thumbnail = thumbnail;
            PublishedAt = publishedAt;
            ViewCount = viewCount;
        }

        public string ChannelId { get; }
        public string Title { get; }
        public string Thumbnail { get; }
        public DateTime PublishedAt { get; }
        public int ViewCount { get; }
    }
}
