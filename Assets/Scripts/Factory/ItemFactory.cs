using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Factory
{
    public class ItemFactory : object
    {
        protected static int GetNbOfPointsToAllocateForLevel(int level)
        {
            return Random.Range(level - 1, (level * 5) + 1);
        }

        protected static int GetNbOfPointsToRemoveForLevel(int level)
        {
            return Random.Range(0, level);
        }

        protected static int[] GetRandomStatsArray(int level)
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
    }
}
