using ApplicationService.Videos.GetRange;
using ApplicationService.Videos.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Videos
{
    public interface IVideoQueryService
    {
        VideoSearchResult Search(VideoSearchCommand command);
        VideoGetRangeResult GetRange(VideoGetRangeCommand command);
    }
}
