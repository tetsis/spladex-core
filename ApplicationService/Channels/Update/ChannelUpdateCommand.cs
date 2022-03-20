using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Channels.Update
{
    public class ChannelUpdateCommand
    {
        public string UserId { get; init; }
        public string SessionId { get; init; }
        public string ChannelId { get; init; }
    }
}
