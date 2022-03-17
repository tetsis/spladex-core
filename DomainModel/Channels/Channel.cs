using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Channels
{
    public class Channel
    {
        // 再構成用
        public Channel(
            string id,
            string name,
            string thumbnail,
            int subscriberCount)
        {
            Id = id;
            ChannelInfo = new ChannelInfo(name, thumbnail, subscriberCount);
        }

        public Channel(
            string id,
            ChannelInfo channelInfo)
        {
            Id = id;
            ChannelInfo = channelInfo;
        }

        public string Id { get; }
        public ChannelInfo ChannelInfo { get; }
    }
}
