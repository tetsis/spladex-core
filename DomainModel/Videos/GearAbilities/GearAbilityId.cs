using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Videos.GearAbilities
{
    public enum GearAbilityId
    {
        InkSaverMain, // インク効率アップ(メイン)
        InkSaverSub, // インク効率アップ(サブ)
        InkRecoveryUp, // インク回復力アップ
        RunSpeedUp, // ヒト移動速度アップ
        SwimSpeedUp, // イカダッシュ速度アップ
        SpecialChargeUp, // スペシャル増加量アップ
        SpecialSaver, // スペシャル減少量ダウン
        SpecialPowerUp, // スペシャル性能アップ
        QuickRespawn, // 復活時間短縮
        QuickSuperJump, // スーパージャンプ時間短縮
        SubPowerUp, // サブ性能アップ
        InkResistanceUp, // 相手インク影響軽減
        BombDefenseUp, // 爆風ダメージ軽減
        BombDefenseUpDX, // 爆風ダメージ軽減・改
        MainPowerUp, // メイン性能アップ
        OpeningGambit, // スタートダッシュ
        LastDitchEffort, // ラストスパート
        Tenacity, // 逆境強化
        Comeback, // カムバック
        NinjaSquid, // イカニンジャ
        Haunt, // リベンジ
        ThermalInk, // サーマルインク
        RespawnPunisher, // 復活ペナルティアップ
        AbilityDoubler, // 追加ギアパワー倍化
        StealthJump, // ステルスジャンプ
        ObjectShredder, // 対物攻撃力アップ
        DropRoller, // 受け身術
        Rolling // ギアパワー抽選中
    }
}
