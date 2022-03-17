using DomainModel.Videos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Test.Mocks
{
    public class MockVideoFactory : IVideoFactory
    {
        public Video Create(string id, List<Battle> battles)
        {
            var videoInfo = GetVideoInfo(id);
            var video = new Video(id, videoInfo, battles);
            return video;
        }

        public VideoInfo GetVideoInfo(string id)
        {
            var videoInfo = new VideoInfo("channelId", "title", "thumbnail", DateTime.Now, 1);
            return videoInfo;
        }
    }
}
