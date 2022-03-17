using DomainModel.Videos.WeaponTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Videos.Weapons
{
    public class Weapon
    {
        public Weapon(
            WeaponId id,
            WeaponTypeId type,
            string name)
        {
            Id = id;
            Type = type;
            Name = name;
        }

        public WeaponId Id { get; }
        public WeaponTypeId Type { get; }
        public string Name { get; }
    }
}
