using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Videos
{
    public interface IVideoRepository
    {
        Video Find(string id);
        bool ExistsChannel(string channelId);
        List<Video> FindAll();
        void Create(Video video);
        void Delete(string id);
    }
}
