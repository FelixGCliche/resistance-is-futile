using Equipment;
using UnityEngine;

namespace Factory
{
    public static class WeaponFactory
    {
        public static Weapon CreateNewWeapon(int level)
        {
            int[] statsArray = GetRandomStatsArray(level);
            int weaponDamage = Random.Range(level, level * 5);
            return new Weapon(weaponDamage, GetDamageType(), GetWeaponType(), EquipementType.WEAPON, level, statsArray[0], statsArray[1], statsArray[2], statsArray[3], statsArray[4], statsArray[5], statsArray[6], statsArray[7], statsArray[8]);
        }

        private static int[] GetRandomStatsArray(int level)
        {
            int[] statsArray = new int[9];
            int nbOfPointsToAllocate = GetNbOfPointsToAllocateForLevel(level);
            int nbOfPointsToRemove = GetNbOfPointsToRemoveForLevel(level);
            for (int i = 1; i < nbOfPointsToAllocate; i++)
            {
                statsArray[Random.Range(0, 9)]++;
            }
            for (int i = 1; i < nbOfPointsToRemove; i++)
            {
                statsArray[Random.Range(0, 9)]--;
            }
            return statsArray;
        }

        private static int GetNbOfPointsToAllocateForLevel(int level)
        {
            return Random.Range(level - 1, (level * 5) + 1);
        }

        private static int GetNbOfPointsToRemoveForLevel(int level)
        {
            return Random.Range(0, level);
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
