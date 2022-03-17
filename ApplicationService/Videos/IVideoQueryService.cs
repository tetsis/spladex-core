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
    }
}
