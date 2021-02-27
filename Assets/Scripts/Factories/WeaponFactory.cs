using Equipment;
using UnityEngine;

namespace Factory
{
    public class WeaponFactory : ItemFactory
    {
        public static Weapon CreateNewWeapon(int level)
        {
            int[] statsArray = GetRandomStatsArray(level);
            int weaponDamage = Random.Range(level, (level * 5)+1);
            return new Weapon(weaponDamage, GetDamageType(), GetWeaponType(), EquipementType.WEAPON, statsArray[0], statsArray[1], statsArray[2], statsArray[3], statsArray[4], statsArray[5], statsArray[6], statsArray[7], statsArray[8]);
        }

        public static Weapon CreateStartingWeapon(WeaponType weaponType)
        {
            int[] statsArray = GetRandomStatsArray(1);
            int weaponDamage = Random.Range(1, (1 * 5) + 1);
            return new Weapon(weaponDamage, GetDamageType(), weaponType, EquipementType.WEAPON, statsArray[0], statsArray[1], statsArray[2], statsArray[3], statsArray[4], statsArray[5], statsArray[6], statsArray[7], statsArray[8]);
        }

        private static DamageType GetDamageType()
        {
            switch (Random.Range(0, 2))
            {
                case 0:
                    return DamageType.MAGIC;
                case 1:
                    return DamageType.PHYSICAL;
            }
            return DamageType.NONE;
        }

        private static WeaponType GetWeaponType()
        {
            switch (Random.Range(0, 3))
            {
                case 0:
                    return WeaponType.DEXTERITY;
                case 1:
                    return WeaponType.INTELLIGENCE;
                case 2:
                    return WeaponType.STRENGTH;
            }
            return WeaponType.NONE;
        }
    }
}
