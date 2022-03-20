using ApplicationService.Videos.Add;
using ApplicationService.Videos.Export;
using ApplicationService.Videos.Get;
using ApplicationService.Videos.GetAllIds;
using ApplicationService.Videos.GetInfo;
using ApplicationService.Videos.Remove;
using ApplicationService.Videos.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Videos
{
    public interface IVideoApplicationService
    {
        void Add(VideoAddCommand command);
        void Remove(VideoRemoveCommand command);
        void Update(VideoUpdateCommand command);
        VideoGetResult Get(VideoGetCommand command);
        VideoGetInfoResult GetInfo(VideoGetInfoCommand command);
        VideoExportResult Export(VideoExportCommand command);
        VideoGetAllIdsResult GetAllIds();
    }
}
