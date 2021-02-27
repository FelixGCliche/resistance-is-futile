using Equipment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Factory
{
    public class EquipementFactory : ItemFactory
    {
        public static Equipement CreateNewEquipement(int level)
        {
            int[] statsArray = GetRandomStatsArray(level);
            return new Equipement(GetEquipementType(), level, statsArray[0], statsArray[1], statsArray[2], statsArray[3], statsArray[4], statsArray[5], statsArray[6], statsArray[7], statsArray[8]);
        }
        
        public static Equipement CreateNewEquipementWithType(int level, EquipementType type)
        {
            int[] statsArray = GetRandomStatsArray(level);
            return new Equipement(type, level, statsArray[0], statsArray[1], statsArray[2], statsArray[3], statsArray[4], statsArray[5], statsArray[6], statsArray[7], statsArray[8]);
        }

        private static EquipementType GetEquipementType()
        {
            switch (Random.Range(0, 6))
            {
                case 0:
                    return EquipementType.BOOTS;
                case 1:
                    return EquipementType.CHESTPIECE;
                case 2:
                    return EquipementType.GREAVES;
                case 3:
                    return EquipementType.HELMET;
                case 4:
                    return EquipementType.NECKLACE;
                case 5:
                    return EquipementType.RING;
            }
            return EquipementType.NONE;
        }
    }
}
