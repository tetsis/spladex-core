using DomainModel.EditingHistories;
using DomainModel.Videos;
using DomainModel.Videos.Rules;
using DomainModel.Videos.Stages;
using DomainModel.Videos.Weapons;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Test.EditingHistories
{
    [TestClass]
    public class EditingHistoryTest
    {
        [TestMethod]
        public void 動画情報を履歴にする()
        {
            var video = new Video("id",
                new VideoInfo("channelId", "チャンネル", "thumbnail", DateTime.Now, 1),
                new List<Battle>
                {
                    new Battle("id", 0, Rules.GetById(RuleId.ClamBlitz), Stages.GetById(StageId.AnchoVGames), Weapons.GetById(WeaponId.AerosprayMG), 2000)
                });
            var editingHistory = new EditingHistory("userId", OperationType.Add, ContentType.Video, video);

            Assert.IsNotNull(editingHistory);
        }
    }
}
