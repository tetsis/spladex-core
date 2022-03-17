using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Videos.WeaponTypes
{
    public static class WeaponTypes
    {
        private static readonly List<WeaponType> Value = new List<WeaponType>
        {
            new WeaponType(WeaponTypeId.Shooter, "シューター"),
            new WeaponType(WeaponTypeId.Roller, "ローラー"),
            new WeaponType(WeaponTypeId.Charger, "チャージャー"),
            new WeaponType(WeaponTypeId.Slosher, "スロッシャー"),
            new WeaponType(WeaponTypeId.Splatling, "スピナー"),
            new WeaponType(WeaponTypeId.Dualies, "マニューバー"),
            new WeaponType(WeaponTypeId.Brella, "シェルター")
        };

        public static WeaponType[] GetAll()
        {
            return Value.ToArray();
        }

        public static WeaponType GetById(string id)
        {
            return Value.Single(x => x.Id.ToString() == id);
        }

        public static WeaponType GetById(WeaponTypeId id)
        {
            return Value.Single(x => x.Id == id);
        }

        public static WeaponType GetByName(string name)
        {
            return Value.Single(x => x.Name == name);
        }
    }
}
