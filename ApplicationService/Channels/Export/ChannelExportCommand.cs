using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Channels.Export
{
    public class ChannelExportCommand
    {
        public string UserId { get; init; }
        public string SessionId { get; init; }
    }
}
