using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Videos.Stages
{
    public static class Stages
    {
        private static List<Stage> Value = new List<Stage>
        {
            new Stage(StageId.TheReef, "バッテラストリート"),
            new Stage(StageId.MusselforgeFitness, "フジツボスポーツクラブ"),
            new Stage(StageId.StarfishMainstage, "ガンガゼ野外音楽堂"),
            new Stage(StageId.MorayTowers, "タチウオパーキング"),
            new Stage(StageId.HumpbackPumpTrack, "コンブトラック"),
            new Stage(StageId.InkblotArtAcademy, "海女美術大学"),
            new Stage(StageId.SturgeonShipyard, "チョウザメ造船"),
            new Stage(StageId.PortMackerel, "ホッケふ頭"),
            new Stage(StageId.MantaMaria, "マンタマリア号"),
            new Stage(StageId.KelpDome, "モズク農園"),
            new Stage(StageId.SnapperCanal, "エンガワ河川敷"),
            new Stage(StageId.BlackbellySkatepark, "Bバスパーク"),
            new Stage(StageId.MakoMart, "ザトウマーケット"),
            new Stage(StageId.WalleyeWarehouse, "ハコフグ倉庫"),
            new Stage(StageId.ShellendorfInstitute, "デボン海洋博物館"),
            new Stage(StageId.ArowanaMall, "アロワナモール"),
            new Stage(StageId.GobyArena, "アジフライスタジアム"),
            new Stage(StageId.PiranhaPit, "ショッツル鉱山"),
            new Stage(StageId.CampTriggerfish, "モンガラキャンプ場"),
            new Stage(StageId.WahooWorld, "スメーシーワールド"),
            new Stage(StageId.NewwAlbacoreHotel, "ホテルニューオートロ"),
            new Stage(StageId.AnchoVGames, "アンチョビットゲームズ"),
            new Stage(StageId.SkipperPavilion, "ムツゴ楼")
        };

        public static Stage[] GetAll()
        {
            return Value.ToArray();
        }

        public static Stage GetById(string id)
        {
            return Value.Single(x => x.Id.ToString() == id);
        }

        public static Stage GetById(StageId id)
        {
            return Value.Single(x => x.Id == id);
        }

        public static Stage GetByName(string name)
        {
            return Value.Single(x => x.Name == name);
        }
    }
}
