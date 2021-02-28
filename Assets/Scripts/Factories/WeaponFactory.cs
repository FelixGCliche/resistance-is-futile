using Battle;
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
            return new Weapon(weaponDamage, GetDamageType(), GetWeaponType(), GetAttackType(), EquipementType.WEAPON, statsArray[0], statsArray[1], statsArray[2], statsArray[3], statsArray[4], statsArray[5], statsArray[6], statsArray[7], statsArray[8]);
        }

        public static Weapon CreateStartingWeapon(WeaponType weaponType)
        {
            return new Weapon(5, GetDamageType(), weaponType, AttackType.SINGLE_TARGET, EquipementType.WEAPON, 0, 0, 0, 0, 0, 0, 0, 0, 0);
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

        private static AttackType GetAttackType()
        {
            switch (Random.Range(0, 2))
            {
                case 0:
                    return AttackType.SINGLE_TARGET;
                case 1:
                    return AttackType.AOE;
                case 2:
                    return AttackType.SPLASH;
                case 3:
                    return AttackType.SPLASH_UP;
                case 4:
                    return AttackType.SPLASH_DOWN;
            }
            return AttackType.NONE;
        }
    }
}
