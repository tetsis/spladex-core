using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Videos.GearAbilities
{
    public static class GearAbilities
    {
        private static List<GearAbility> Value = new List<GearAbility>
        {
            new GearAbility(GearAbilityId.InkSaverMain, "インク効率アップ(メイン)", anyWhere: true),
            new GearAbility(GearAbilityId.InkSaverSub, "インク効率アップ(サブ)", anyWhere: true),
            new GearAbility(GearAbilityId.InkRecoveryUp, "インク回復力アップ", anyWhere: true),
            new GearAbility(GearAbilityId.RunSpeedUp, "ヒト移動速度アップ", anyWhere: true),
            new GearAbility(GearAbilityId.SwimSpeedUp, "イカダッシュ速度アップ", anyWhere: true),
            new GearAbility(GearAbilityId.SpecialChargeUp, "スペシャル増加量アップ", anyWhere: true),
            new GearAbility(GearAbilityId.SpecialSaver, "スペシャル減少量ダウン", anyWhere: true),
            new GearAbility(GearAbilityId.SpecialPowerUp, "スペシャル性能アップ", anyWhere: true),
            new GearAbility(GearAbilityId.QuickRespawn, "復活時間短縮", anyWhere: true),
            new GearAbility(GearAbilityId.QuickSuperJump, "スーパージャンプ時間短縮", anyWhere: true),
            new GearAbility(GearAbilityId.SubPowerUp, "サブ性能アップ", anyWhere: true),
            new GearAbility(GearAbilityId.InkResistanceUp, "相手インク影響軽減", anyWhere: true),
            new GearAbility(GearAbilityId.BombDefenseUp, "爆風ダメージ軽減", anyWhere: true),
            new GearAbility(GearAbilityId.BombDefenseUpDX, "爆風ダメージ軽減・改", anyWhere: true),
            new GearAbility(GearAbilityId.MainPowerUp, "メイン性能アップ", anyWhere: true),
            new GearAbility(GearAbilityId.OpeningGambit, "スタートダッシュ", headOnly: true),
            new GearAbility(GearAbilityId.LastDitchEffort, "ラストスパート", headOnly: true),
            new GearAbility(GearAbilityId.Tenacity, "逆境強化", headOnly: true),
            new GearAbility(GearAbilityId.Comeback, "カムバック", headOnly: true),
            new GearAbility(GearAbilityId.NinjaSquid, "イカニンジャ", clothingOnly: true),
            new GearAbility(GearAbilityId.Haunt, "リベンジ", clothingOnly: true),
            new GearAbility(GearAbilityId.ThermalInk, "サーマルインク", clothingOnly: true),
            new GearAbility(GearAbilityId.RespawnPunisher, "復活ペナルティアップ", clothingOnly: true),
            new GearAbility(GearAbilityId.AbilityDoubler, "追加ギアパワー倍化", clothingOnly: true),
            new GearAbility(GearAbilityId.StealthJump, "ステルスジャンプ", shoesOnly: true),
            new GearAbility(GearAbilityId.ObjectShredder, "対物攻撃力アップ", shoesOnly: true),
            new GearAbility(GearAbilityId.DropRoller, "受け身術", shoesOnly: true),
            new GearAbility(GearAbilityId.Rolling, "ギアパワー抽選中")
        };

        public static GearAbility[] GetAll()
        {
            return Value.ToArray();
        }

        public static GearAbility GetById(string id)
        {
            return Value.Single(x => x.Id.ToString() == id);
        }

        public static GearAbility GetById(GearAbilityId id)
        {
            return Value.Single(x => x.Id == id);
        }

        public static GearAbility GetByName(string name)
        {
            return Value.Single(x => x.Name == name);
        }
    }
}
