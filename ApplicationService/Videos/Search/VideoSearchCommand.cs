using DomainModel.Videos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Videos.Search
{
    public class VideoSearchCommand
    {
        public string? Channel { get; init; }
        public string? Rule { get; init; }
        public string? Stage { get; init; }
        public string? Weapon { get; init; }
        public int? MinRoomPower { get; init; }
        public int? MaxRoomPower { get; init; }
        public string? Sort { get; init; }
        public int Page { get; init; }
        public string? UserId { get; init; }
    }
}
