using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Videos
{
    public enum Sort
    {
        PublishedAtAsc, // 投稿日（昇順）
        PublishedAtDesc, // 投稿日（降順）
        ViewCountAsc, // 再生回数,（昇順）
        ViewCountDesc, // 再生回数,（降順）
        RoomPowerAsc, // 部屋パワー昇順
        RoomPowerDesc // 部屋パワー降順
    }
}
