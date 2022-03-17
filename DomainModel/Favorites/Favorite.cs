using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Favorites
{
    public class Favorite
    {
        public Favorite(
            string userId,
            string videoId,
            int battleIndex)
        {
            UserId = userId;
            VideoId = videoId;
            BattleIndex = battleIndex;
            CreateTime = DateTime.Now;
        }

        public string UserId { get; }
        public string VideoId { get; }
        public int BattleIndex { get; }
        public DateTime CreateTime { get; }
    }
}
