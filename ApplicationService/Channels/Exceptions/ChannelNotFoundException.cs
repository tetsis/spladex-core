using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Channels.Exceptions
{
    public class ChannelNotFoundException : Exception
    {
        public ChannelNotFoundException(string channelId, string message) : base(message)
        {
            ChannelId = channelId;
        }

        public string ChannelId { get; }
    }
}
