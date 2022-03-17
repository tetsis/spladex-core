using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Videos
{
    public class Video
    {
        // 再構成用
        public Video(
            string id,
            string channelId,
            string title,
            string thumbnail,
            DateTime publishedAt,
            int viewCount,
            List<Battle> battles)
        {
            Id = id;
            VideoInfo = new VideoInfo(channelId, title, thumbnail, publishedAt, viewCount);
            Battles = battles;
        }

        public Video(
            string id,
            VideoInfo videoInfo,
            List<Battle> battles)
        {
            Id = id;
            VideoInfo = videoInfo;
            Battles = battles;
        }

        public string Id { get; }
        public VideoInfo VideoInfo { get; }
        public List<Battle> Battles { get; }
    }
}
