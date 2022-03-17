using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Videos.Search
{
    public class VideoSearchResult
    {
        public List<BattleDataForQuery> Battles { get; init; }
        public int PageNumber { get; init; }
        public int ResultNumber { get; init; }
    }
}
