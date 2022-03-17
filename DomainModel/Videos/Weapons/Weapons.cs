using DomainModel.Videos.WeaponTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Videos.Weapons
{
    public static class Weapons
    {
        private static readonly List<Weapon> Value = new List<Weapon>
        {
            new Weapon(WeaponId.Sploosh_o_matic, WeaponTypeId.Shooter, "ボールドマーカー"),
            new Weapon(WeaponId.NeoSploosh_o_matic, WeaponTypeId.Shooter, "ボールドマーカーネオ"),
            new Weapon(WeaponId.Sploosh_o_matic7, WeaponTypeId.Shooter, "ボールドマーカー7"),
            new Weapon(WeaponId.SplattershotJr, WeaponTypeId.Shooter, "わかばシューター"),
            new Weapon(WeaponId.CustomeSplattershotJr, WeaponTypeId.Shooter, "もみじシューター"),
            new Weapon(WeaponId.KensaSplattershotJr, WeaponTypeId.Shooter, "おちばシューター"),
            new Weapon(WeaponId.Splash_o_matic, WeaponTypeId.Shooter, "シャープマーカー"),
            new Weapon(WeaponId.NeoSplash_o_matic, WeaponTypeId.Shooter, "シャープマーカーネオ"),
            new Weapon(WeaponId.AerosprayMG, WeaponTypeId.Shooter, "プロモデラーMG"),
            new Weapon(WeaponId.AerosprayRG, WeaponTypeId.Shooter, "プロモデラーRG"),
            new Weapon(WeaponId.AerosprayPG, WeaponTypeId.Shooter, "プロモデラーPG"),
            new Weapon(WeaponId.Splattershot, WeaponTypeId.Shooter, "スプラシューター"),
            new Weapon(WeaponId.TentatekSplattershot, WeaponTypeId.Shooter, "スプラシューターコラボ"),
            new Weapon(WeaponId.KensaSplattershot, WeaponTypeId.Shooter, "スプラシューターベッチュー"),
            new Weapon(WeaponId._52Gal, WeaponTypeId.Shooter, ".52ガロン"),
            new Weapon(WeaponId._52GalDeco, WeaponTypeId.Shooter, ".52ガロンデコ"),
            new Weapon(WeaponId.Kensa_52Gal, WeaponTypeId.Shooter, ".52ガロンベッチュー"),
            new Weapon(WeaponId.N_ZAP85, WeaponTypeId.Shooter, "N-ZAP85"),
            new Weapon(WeaponId.N_ZAP89, WeaponTypeId.Shooter, "N-ZAP89"),
            new Weapon(WeaponId.N_ZAP83, WeaponTypeId.Shooter, "N-ZAP83"),
            new Weapon(WeaponId.SplattershotPro, WeaponTypeId.Shooter, "プライムシューター"),
            new Weapon(WeaponId.ForgeSplattershotPro, WeaponTypeId.Shooter, "プライムシューターコラボ"),
            new Weapon(WeaponId.KensaSplattershotPro, WeaponTypeId.Shooter, "プライムシューターベッチュー"),
            new Weapon(WeaponId._96Gal, WeaponTypeId.Shooter, ".96ガロン"),
            new Weapon(WeaponId._96GalDeco, WeaponTypeId.Shooter, ".96ガロンデコ"),
            new Weapon(WeaponId.JetSquelcher, WeaponTypeId.Shooter, "ジェットスイーパー"),
            new Weapon(WeaponId.CustomeJetSquelcher, WeaponTypeId.Shooter, "ジェットスイーパーカスタム"),
            new Weapon(WeaponId.L_3Nozzlenose, WeaponTypeId.Shooter, "L3リールガン"),
            new Weapon(WeaponId.L_3NozzlenoseD, WeaponTypeId.Shooter, "L3リールガンD"),
            new Weapon(WeaponId.KensaL_3Nozzlenose, WeaponTypeId.Shooter, "L3リールガンベッチュー"),
            new Weapon(WeaponId.H_3Nozzlenose, WeaponTypeId.Shooter, "H3リールガン"),
            new Weapon(WeaponId.H_3NozzlenoseD, WeaponTypeId.Shooter, "H3リールガンD"),
            new Weapon(WeaponId.CherryH_3Nozzlenose, WeaponTypeId.Shooter, "H3リールガンチェリー"),
            new Weapon(WeaponId.Squeezer, WeaponTypeId.Shooter, "ボトルガイザー"),
            new Weapon(WeaponId.FoilSqueezer, WeaponTypeId.Shooter, "ボトルガイザーフォイル"),
            new Weapon(WeaponId.LunaBlaster, WeaponTypeId.Shooter, "ノヴァブラスター"),
            new Weapon(WeaponId.LunaBlasterNeo, WeaponTypeId.Shooter, "ノヴァブラスターネオ"),
            new Weapon(WeaponId.KensaLunaBlaster, WeaponTypeId.Shooter, "ノヴァブラスターベッチュー"),
            new Weapon(WeaponId.Blaster, WeaponTypeId.Shooter, "ホットブラスター"),
            new Weapon(WeaponId.CustomeBlaster, WeaponTypeId.Shooter, "ホットブラスターカスタム"),
            new Weapon(WeaponId.RangeBlaster, WeaponTypeId.Shooter, "ロングブラスター"),
            new Weapon(WeaponId.CustomRangeBlaster, WeaponTypeId.Shooter, "ロングブラスターカスタム"),
            new Weapon(WeaponId.GrimRangeBlaster, WeaponTypeId.Shooter, "ロングブラスターネクロ"),
            new Weapon(WeaponId.ClashBlaster, WeaponTypeId.Shooter, "クラッシュブラスター"),
            new Weapon(WeaponId.ClashBlasterNeo, WeaponTypeId.Shooter, "クラッシュブラスターネオ"),
            new Weapon(WeaponId.RapidBlaster, WeaponTypeId.Shooter, "ラピッドブラスター"),
            new Weapon(WeaponId.RapidBlasterDeco, WeaponTypeId.Shooter, "ラピッドブラスターデコ"),
            new Weapon(WeaponId.KensaRapidBlaster, WeaponTypeId.Shooter, "ラピッドブラスターベッチュー"),
            new Weapon(WeaponId.RapidBlasterPro, WeaponTypeId.Shooter, "Rブラスターエリート"),
            new Weapon(WeaponId.RapidBlasterProDeco, WeaponTypeId.Shooter, "Rブラスターエリートデコ"),
            new Weapon(WeaponId.CarbonRoller, WeaponTypeId.Roller, "カーボンローラー"),
            new Weapon(WeaponId.CarbonRollerDeco, WeaponTypeId.Roller, "カーボンローラデコ"),
            new Weapon(WeaponId.SplatRoller, WeaponTypeId.Roller, "スプラローラー"),
            new Weapon(WeaponId.Krak_OnSplatRoller, WeaponTypeId.Roller, "スプラローラーコラボ"),
            new Weapon(WeaponId.KensaSplatRoller, WeaponTypeId.Roller, "スプラローラーベッチュー"),
            new Weapon(WeaponId.DynamoRoller, WeaponTypeId.Roller, "ダイナモローラー"),
            new Weapon(WeaponId.GoldDynamoRoller, WeaponTypeId.Roller, "ダイナモローラーテスラ"),
            new Weapon(WeaponId.KensaDynamoRoller, WeaponTypeId.Roller, "ダイナモローラーベッチュー"),
            new Weapon(WeaponId.FlingzaRoller, WeaponTypeId.Roller, "ヴァリアブルローラー"),
            new Weapon(WeaponId.FoilFlingzaRoller, WeaponTypeId.Roller, "ヴァリアブルローラーフォイル"),
            new Weapon(WeaponId.Inkbrush, WeaponTypeId.Roller, "パブロ"),
            new Weapon(WeaponId.InkbrushNouveau, WeaponTypeId.Roller, "パブロ・ヒュー"),
            new Weapon(WeaponId.PermanentInkbrush, WeaponTypeId.Roller, "パーマネント・パブロ"),
            new Weapon(WeaponId.Octobrush, WeaponTypeId.Roller, "ホクサイ"),
            new Weapon(WeaponId.OctobrushNouveau, WeaponTypeId.Roller, "ホクサイ・ヒュー"),
            new Weapon(WeaponId.KensaOctobrush, WeaponTypeId.Roller, "ホクサイベッチュー"),
            new Weapon(WeaponId.ClasicSquiffer, WeaponTypeId.Charger, "スクイックリンα"),
            new Weapon(WeaponId.NewSquiffer, WeaponTypeId.Charger, "スクイックリンβ"),
            new Weapon(WeaponId.FreshSquiffer, WeaponTypeId.Charger, "スクイックリンγ"),
            new Weapon(WeaponId.SplatCharger, WeaponTypeId.Charger, "スプラチャージャー"),
            new Weapon(WeaponId.FirefinSplatCharger, WeaponTypeId.Charger, "スプラチャージャーコラボ"),
            new Weapon(WeaponId.KensaSplatCharger, WeaponTypeId.Charger, "スプラチャージャーベッチュー"),
            new Weapon(WeaponId.Splatterscope, WeaponTypeId.Charger, "スプラスコープ"),
            new Weapon(WeaponId.FirefinSplatterscope, WeaponTypeId.Charger, "スプラスコープコラボ"),
            new Weapon(WeaponId.KensaSplatterscope, WeaponTypeId.Charger, "スプラスコープベッチュー"),
            new Weapon(WeaponId.E_liter4K, WeaponTypeId.Charger, "リッター4K"),
            new Weapon(WeaponId.CustomE_liter4K, WeaponTypeId.Charger, "リッター4Kカスタム"),
            new Weapon(WeaponId.E_liter4KScope, WeaponTypeId.Charger, "4Kスコープ"),
            new Weapon(WeaponId.CustomeE_liter4KScope, WeaponTypeId.Charger, "4Kスコープカスタム"),
            new Weapon(WeaponId.Bamboozler14MkI, WeaponTypeId.Charger, "14式竹筒銃・甲"),
            new Weapon(WeaponId.Bamboozler14MkII, WeaponTypeId.Charger, "14式竹筒銃・乙"),
            new Weapon(WeaponId.Bamboozler14MkIII, WeaponTypeId.Charger, "14式竹筒銃・丙"),
            new Weapon(WeaponId.GooTuber, WeaponTypeId.Charger, "ソイチューバー"),
            new Weapon(WeaponId.CustomGooTuber, WeaponTypeId.Charger, "ソイチューバーカスタム"),
            new Weapon(WeaponId.Slosher, WeaponTypeId.Slosher, "バケットスロッシャー"),
            new Weapon(WeaponId.SlosherDeco, WeaponTypeId.Slosher, "バケットスロッシャーデコ"),
            new Weapon(WeaponId.SlosherSoda, WeaponTypeId.Slosher, "バケットスロッシャーソーダ"),
            new Weapon(WeaponId.Tri_Slosher, WeaponTypeId.Slosher, "ヒッセン"),
            new Weapon(WeaponId.Tri_SlosherNouveau, WeaponTypeId.Slosher, "ヒッセン・ヒュー"),
            new Weapon(WeaponId.SloshingMachine, WeaponTypeId.Slosher, "スクリュースロッシャー"),
            new Weapon(WeaponId.SloshingMachineNeo, WeaponTypeId.Slosher, "スクリュースロッシャーネオ"),
            new Weapon(WeaponId.KensaSloshingMachine, WeaponTypeId.Slosher, "スクリュースロッシャーベッチュー"),
            new Weapon(WeaponId.Bloblobber, WeaponTypeId.Slosher, "オーバーフロッシャー"),
            new Weapon(WeaponId.BloblobberDeco, WeaponTypeId.Slosher, "オーバーフロッシャーデコ"),
            new Weapon(WeaponId.Explosher, WeaponTypeId.Slosher, "エクスプロッシャー"),
            new Weapon(WeaponId.CustomExplosher, WeaponTypeId.Slosher, "エクスプロッシャーカスタム"),
            new Weapon(WeaponId.MiniSplatling, WeaponTypeId.Splatling, "スプラスピナー"),
            new Weapon(WeaponId.ZinkMiniSplatling, WeaponTypeId.Splatling, "スプラスピナーコラボ"),
            new Weapon(WeaponId.KensaMiniSplatling, WeaponTypeId.Splatling, "スプラスピナーベッチュー"),
            new Weapon(WeaponId.HeavySplatling, WeaponTypeId.Splatling, "バレルスピナー"),
            new Weapon(WeaponId.HeavySplatlingDeco, WeaponTypeId.Splatling, "バレルスピナーデコ"),
            new Weapon(WeaponId.HeavySplatlingRemix, WeaponTypeId.Splatling, "バレルスピナーリミックス"),
            new Weapon(WeaponId.HydraSplatling, WeaponTypeId.Splatling, "ハイドラント"),
            new Weapon(WeaponId.CustomHydraSplatling, WeaponTypeId.Splatling, "ハイドラントカスタム"),
            new Weapon(WeaponId.BallpointSplatling, WeaponTypeId.Splatling, "クーゲルシュライバー"),
            new Weapon(WeaponId.BallpointSplatlingNouveau, WeaponTypeId.Splatling, "クーゲルシュライバー・ヒュー"),
            new Weapon(WeaponId.Nautilus47, WeaponTypeId.Splatling, "ノーチラス47"),
            new Weapon(WeaponId.Nautilus79, WeaponTypeId.Splatling, "ノーチラス79"),
            new Weapon(WeaponId.DappleDualies, WeaponTypeId.Dualies, "スパッタリー"),
            new Weapon(WeaponId.DappleDualiesNouveau, WeaponTypeId.Dualies, "スパッタリー・ヒュー"),
            new Weapon(WeaponId.ClearDappleDualies, WeaponTypeId.Dualies, "スパッタリークリア"),
            new Weapon(WeaponId.SplatDualies, WeaponTypeId.Dualies, "スプラマニューバー"),
            new Weapon(WeaponId.EnperrySplatDualies, WeaponTypeId.Dualies, "スプラマニューバーコラボ"),
            new Weapon(WeaponId.KensaSplatDualies, WeaponTypeId.Dualies, "スプラマニューバーベッチュー"),
            new Weapon(WeaponId.GloogaDualies, WeaponTypeId.Dualies, "ケルビン525"),
            new Weapon(WeaponId.GloogaDualiesDeco, WeaponTypeId.Dualies, "ケルビン525デコ"),
            new Weapon(WeaponId.KensaGloogaDualies, WeaponTypeId.Dualies, "ケルビン525ベッチュー"),
            new Weapon(WeaponId.DualieSquelchers, WeaponTypeId.Dualies, "デュアルスイーパー"),
            new Weapon(WeaponId.CustomDualieSquelchers, WeaponTypeId.Dualies, "デュアルスイーパーカスタム"),
            new Weapon(WeaponId.DarkTetraDualies, WeaponTypeId.Dualies, "クアッドホッパーブラック"),
            new Weapon(WeaponId.LightTetraDualies, WeaponTypeId.Dualies, "クアッドホッパーホワイト"),
            new Weapon(WeaponId.SplatBrella, WeaponTypeId.Brella, "パラシェルター"),
            new Weapon(WeaponId.SorellaBrella, WeaponTypeId.Brella, "パラシェルターソレーラ"),
            new Weapon(WeaponId.TentaBrella, WeaponTypeId.Brella, "キャンピングシェルター"),
            new Weapon(WeaponId.TentaSorellaBrella, WeaponTypeId.Brella, "キャンピングシェルターソレーラ"),
            new Weapon(WeaponId.TentaCamoBrella, WeaponTypeId.Brella, "キャンピングシェルターカーモ"),
            new Weapon(WeaponId.UndercoverBrella, WeaponTypeId.Brella, "スパイガジェット"),
            new Weapon(WeaponId.UndercoverSorellaBrella, WeaponTypeId.Brella, "スパイガジェットソレーラ"),
            new Weapon(WeaponId.KensaUndercoverBrella, WeaponTypeId.Brella, "スパイガジェットベッチュー")
        };

        public static Weapon[] GetAll()
        {
            return Value.ToArray();
        }

        public static Weapon GetById(string id)
        {
            return Value.Single(x => x.Id.ToString() == id);
        }

        public static Weapon GetById(WeaponId id)
        {
            return Value.Single(x => x.Id == id);
        }

        public static Weapon GetByName(string name)
        {
            return Value.Single(x => x.Name == name);
        }
    }
}
