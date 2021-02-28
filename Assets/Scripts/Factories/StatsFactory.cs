using Stats;
using System;
using Stats;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Factory
{
    class StatsFactory
    {
        const int STAT_BONUS_BY_LEVEL = 3;

        private static int[] wizardBaseStats = new int[9] { 20, 0, 1, 3, 1, 1, 3, 5, 5 };
        private static int[] warriorBaseStats = new int[9] { 25, 1, 0, 2, 3, 1, 1, 5, 3 };
        private static int[] huntressBaseStats = new int[9] { 20, 0, 0, 5, 1, 3, 1, 5, 7 };
        private static int[] goblinBaseStats = new int[9] { 15, 0, 0, 2, 1, 1, 1, 5, 7 };
        private static int[] flyingEyeBaseStats = new int[9] { 20, 0, 1, 1, 1, 1, 1, 5, 5 };
        private static int[] skeletonBaseStats = new int[9] { 20, 1, 0, 1, 1, 1, 1, 5, 3 };

        private static int GetNbOfPointsToAllocateForLevel(int level)
        {
            return level * STAT_BONUS_BY_LEVEL;
        }

        public static CharacterStats CreateStartingCharacterStatsByType(CharacterType characterType)
        {
            int[] baseStats = new int[9];

            switch (characterType)
            {
                case CharacterType.WIZARD:
                    baseStats = wizardBaseStats;
                    break;
                case CharacterType.WARRIOR:
                    baseStats = warriorBaseStats;
                    break;
                case CharacterType.HUNTRESS:
                    baseStats = huntressBaseStats;
                    break;
                case CharacterType.SKELETON:
                    baseStats = skeletonBaseStats;
                    break;
                case CharacterType.GOBLIN:
                    baseStats = goblinBaseStats;
                    break;
                case CharacterType.FLYING_EYE:
                    baseStats = flyingEyeBaseStats;
                    break;
            }

            CharacterStats characterStats = new CharacterStats(baseStats[0], baseStats[1], baseStats[2], baseStats[3], baseStats[4], baseStats[5], baseStats[6], baseStats[7], baseStats[8]);
            return characterStats;
        }

        public static CharacterStats CreateEnemyStats(int level)
        {
            int[] baseStats = new int[9];

            switch (Random.Range(0, 3))
            {
                case 0:
                    //Skeleton
                    baseStats = skeletonBaseStats;
                    break;
                case 1:
                    //Goblin
                    baseStats = goblinBaseStats;
                    break;
                case 2:
                    //Flying_Eye
                    baseStats = flyingEyeBaseStats;
                    break;
            }

            for (int i = 0; i < GetNbOfPointsToAllocateForLevel(level); i++)
            {
                baseStats[Random.Range(0, 9)]++;
            }

            CharacterStats characterStats = new CharacterStats(baseStats[0], baseStats[1], baseStats[2], baseStats[3], baseStats[4], baseStats[5], baseStats[6], baseStats[7], baseStats[8]);
            return characterStats;
        }
    }
}
