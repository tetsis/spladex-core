using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Videos.WeaponTypes
{
    public class WeaponType
    {
        public WeaponType(
            WeaponTypeId id,
            string name)
        {
            Id = id;
            Name = name;
        }

        public WeaponTypeId Id { get; }
        public string Name { get; } 
    }
}
