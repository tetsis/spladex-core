using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Videos.Rules
{
    public static class Rules
    {
        private static List<Rule> Value = new List<Rule>
        {
            new Rule(RuleId.SplatZones, "ガチエリア"),
            new Rule(RuleId.TowerControl, "ガチヤグラ"),
            new Rule(RuleId.Rainmaker, "ガチホコ"),
            new Rule(RuleId.ClamBlitz, "ガチアサリ")
        };

        public static Rule[] GetAll()
        {
            return Value.ToArray();
        }

        public static Rule GetById(string id)
        {
            return Value.Single(x => x.Id.ToString() == id);
        }

        public static Rule GetById(RuleId id)
        {
            return Value.Single(x => x.Id == id);
        }

        public static Rule GetByName(string name)
        {
            return Value.Single(x => x.Name == name);
        }
    }
}
