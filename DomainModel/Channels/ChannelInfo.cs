using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Channels
{
    public class ChannelInfo
    {
        public ChannelInfo(
            string name,
            string thumbnail,
            int subscriberCount)
        {
            Name = name;
            Thumbnail = thumbnail;
            SubscriberCount = subscriberCount;
        } 

        public string Name { get; }
        public string Thumbnail { get; }
        public int SubscriberCount { get; }
    }
}
