using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Favorites.Commons
{
    public class FavoriteCommand
    {
        public string UserId { get; init; }
        public string SessionId { get; init; }
        public string VideoId { get; init; }
        public int BattleIndex { get; init; }
    }
}
