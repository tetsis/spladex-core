using DomainModel.Channels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Test.Mocks
{
    public class MockChannelFactory : IChannelFactory
    {
        public Channel Create(string id)
        {
            var channelInfo = GetChannelInfo(id);
            var channel = new Channel(id, channelInfo);
            return channel;
        }

        public ChannelInfo GetChannelInfo(string id)
        {
            var channelInfo = new ChannelInfo("name", "thumbnail", 1);
            return channelInfo;
        }
    }
}
