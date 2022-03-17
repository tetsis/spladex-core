using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Channels.Remove
{
    public class ChannelRemoveCommand
    {
        public string UserId { get; init; }
        public string SessionId { get; init; }
        public string ChannelId { get; init; }
    }
}
