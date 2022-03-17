using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Channels
{
    public interface IChannelFactory
    {
        Channel Create(string id);
        ChannelInfo GetChannelInfo(string id);
    }
}
