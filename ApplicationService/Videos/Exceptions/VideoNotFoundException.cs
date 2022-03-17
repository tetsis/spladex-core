using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Videos.Exceptions
{
    public class VideoNotFoundException : Exception
    {
        public VideoNotFoundException(string videoId, string message) : base(message)
        {
            VideoId = videoId;
        }

        public string VideoId { get; }
    }
}
