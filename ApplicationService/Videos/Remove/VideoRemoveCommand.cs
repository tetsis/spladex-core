using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Videos.Remove
{
    public class VideoRemoveCommand
    {
        public string UserId { get; init; }
        public string SessionId { get; init; }
        public string VideoId { get; init; }
    }
}
