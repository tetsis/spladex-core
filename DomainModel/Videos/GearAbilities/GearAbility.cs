using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Videos.GearAbilities
{
    public class GearAbility
    {
        public GearAbility(
            GearAbilityId id,
            string name,
            bool anyWhere = false,
            bool headOnly = false,
            bool clothingOnly = false,
            bool shoesOnly = false)
        {
            Id = id;
            Name = name;
            AnyWhere = anyWhere;
            HeadOnly = headOnly;
            ClothingOnly = clothingOnly;
            ShoesOnly = shoesOnly;
        } 

        public GearAbilityId Id { get; }
        public string Name { get; }
        public bool AnyWhere { get; }
        public bool HeadOnly { get; }
        public bool ClothingOnly { get; }
        public bool ShoesOnly { get; }
    }
}
