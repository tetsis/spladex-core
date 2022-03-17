using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Videos.Search
{
    public record BattleDataForQuery
    {
        public string ChannelName { get; init; }
        public string VideoId { get; init; }
        public DateTime PublishedAt { get; init; }
        public string Thumbnail { get; init; }
        public int ViewCount { get; init; }
        public int BattleIndex { get; init; }
        public string RuleName { get; init; }
        public string StageName { get; init; }
        public string WeaponName { get; init; }
        public int RoomPower { get; init; }
        public string Url { get; init; }
        public bool IsFavorite { get; init; }
    }
}
