using ApplicationService.Videos.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Videos.Add
{
    public class VideoAddCommand
    {
        public string UserId { get; init; }
        public string SessionId { get; init; }
        public VideoAddData Video { get; init; }
    }
}
