using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Channels
{
    public interface IChannelRepository
    {
        Channel Find(string id);
        List<Channel> FindAll();
        void Create(Channel channel);
        void Delete(string id);
    }
}
