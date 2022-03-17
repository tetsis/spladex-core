using DomainModel.Channels;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebInfrastructure.Channels
{
    public class WebChannelFactory : IChannelFactory
    {
        private readonly IApiKey _apiKey;

        public WebChannelFactory(IApiKey apiKey)
        {
            _apiKey = apiKey;
        }

        public Channel Create(string id)
        {
            var channelInfo = GetChannelInfo(id);

            var channel = new Channel(id, channelInfo);
            return channel;
        }

        public ChannelInfo GetChannelInfo(string id)
        {
            string channelUrl = $"https://www.googleapis.com/youtube/v3/channels?part=snippet,statistics&id={id}&key={_apiKey.Value}";
            dynamic d = channelUrl.GetJsonAsync().Result;
            string title = d.items[0].snippet.title;
            string thumbnail = d.items[0].snippet.thumbnails.medium.url;
            int subscriberCount = int.Parse(d.items[0].statistics.subscriberCount);

            var channelInfo = new ChannelInfo(title, thumbnail, subscriberCount);
            return channelInfo;
        }
    }
}
