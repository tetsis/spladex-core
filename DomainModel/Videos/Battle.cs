using DomainModel.Videos.Rules;
using DomainModel.Videos.Stages;
using DomainModel.Videos.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Videos
{
    public class Battle
    {
        // 再構成用
        public Battle(
            int seconds,
            string rule,
            string stage,
            string weapon,
            int roomPower)
        {
            Seconds = seconds;
            Rule = Rules.Rules.GetById(rule);
            Stage = Stages.Stages.GetById(stage);
            Weapon = Weapons.Weapons.GetById(weapon);
            RoomPower = roomPower;
        }

        public Battle(
            int seconds,
            Rule rule,
            Stage stage,
            Weapon weapon,
            int roomPower)
        {
            Seconds = seconds;
            Rule = rule;
            Stage = stage;
            Weapon = weapon;
            RoomPower = roomPower;
        }

        public int Seconds { get; }
        public Rule Rule { get; }
        public Stage Stage { get; }
        public Weapon Weapon { get; }
        public int RoomPower { get; }
    }
}
