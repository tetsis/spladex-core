using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Videos
{
    public interface IVideoFactory
    {
        Video Create(string id, List<Battle> battles);
        VideoInfo GetVideoInfo(string id);
    }
}
