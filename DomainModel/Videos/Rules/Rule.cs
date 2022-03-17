using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Videos.Rules
{
    public class Rule
    {
        public Rule(
            RuleId id,
            string name)
        {
            Id = id;
            Name = name;
        } 

        public RuleId Id { get; }
        public string Name { get; }
    }
}
