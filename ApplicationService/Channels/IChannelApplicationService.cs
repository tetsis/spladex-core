using ApplicationService.Channels.GetAll;
using ApplicationService.Channels.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Channels
{
    public interface IChannelApplicationService
    {
        void Update(ChannelUpdateCommand command);
        ChannelGetAllResult GetAll();
    }
}
