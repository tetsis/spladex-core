using DomainModel.Videos;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebInfrastructure.Videos
{
    public class WebVideoFactory : IVideoFactory
    {
        private readonly IApiKey _apiKey;

        public WebVideoFactory(IApiKey apiKey)
        {
            _apiKey = apiKey;
        }

        public Video Create(string id, List<Battle> battles)
        {
            var videoInfo = GetVideoInfo(id);

            var video = new Video(id, videoInfo, battles);
            return video;
        }

        public VideoInfo GetVideoInfo(string id)
        {
            string videoUrl = $"https://www.googleapis.com/youtube/v3/videos?part=snippet,statistics&id={id}&key={_apiKey.Value}";
            dynamic d = videoUrl.GetJsonAsync().Result;
            string channelId = d.items[0].snippet.channelId;
            string title = d.items[0].snippet.title;
            string thumbnail = d.items[0].snippet.thumbnails.medium.url;
            DateTime publishedAt = d.items[0].snippet.publishedAt;
            int viewCount = int.Parse(d.items[0].statistics.viewCount);

            var videoInfo = new VideoInfo(channelId, title, thumbnail, publishedAt, viewCount);
            return videoInfo;
        }
    }
}
