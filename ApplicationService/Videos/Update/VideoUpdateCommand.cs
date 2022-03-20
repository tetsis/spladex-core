using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Videos.Update
{
    public class VideoUpdateCommand
    {
        public string UserId { get; init; }
        public string SessionId { get; init; }
        public string VideoId { get; init; }
    }
}
