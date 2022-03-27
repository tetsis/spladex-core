using DomainModel.Videos.Rules;
using DomainModel.Videos.Stages;
using DomainModel.Videos.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Videos.Commons
{
    public class BattleData
    {
        public int Seconds { get; init; }
        public RuleData Rule { get; init; }
        public StageData Stage { get; init; }
        public WeaponData Weapon { get; init; }
        public int RoomPower { get; init; }
    }
}
