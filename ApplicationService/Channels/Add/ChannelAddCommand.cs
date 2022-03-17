using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Channels.Add
{
    public class ChannelAddCommand
    {
        public string UserId { get; init; }
        public string SessionId { get; init; }
        public string ChannelId { get; init; }
    }
}
