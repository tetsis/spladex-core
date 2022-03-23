using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Videos.GetRange
{
    public class VideoGetRangeCommand
    {
        public DateTime PublishedFrom { get; init; }
        public string Channel { get; init; }
    }
}
