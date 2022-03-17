using ApplicationService.Channels.Add;
using ApplicationService.Channels.Export;
using ApplicationService.Channels.Get;
using ApplicationService.Channels.GetAll;
using ApplicationService.Channels.GetInfo;
using ApplicationService.Channels.Remove;
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
        void Add(ChannelAddCommand command);
        void Remove(ChannelRemoveCommand command);
        void Update(ChannelUpdateCommand command);
        ChannelGetAllResult GetAll();
        ChannelGetResult Get(ChannelGetCommand command);
        ChannelGetInfoResult GetInfo(ChannelGetInfoCommand command);
        ChannelExportResult Export(ChannelExportCommand command);
    }
}
