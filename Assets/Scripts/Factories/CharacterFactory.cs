using System;
using Equipment;
using Stats;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Factory
{
  public class CharacterFactory
  {
    const int STAT_BONUS_BY_LEVEL = 3;

    private static int[] wizardBaseStats = new int[9] {1, 1, 1, 1, 1, 1, 1, 1, 1};
    private static int[] warriorBaseStats = new int[9] {1, 1, 1, 1, 1, 1, 1, 1, 1};
    private static int[] huntressBaseStats = new int[9] {1, 1, 1, 1, 1, 1, 1, 1, 1};
    private static int[] goblinBaseStats = new int[9] {1, 1, 1, 1, 1, 1, 1, 1, 1};
    private static int[] flyingEyeBaseStats = new int[9] {1, 1, 1, 1, 1, 1, 1, 1, 1};
    private static int[] skeletonBaseStats = new int[9] {1, 1, 1, 1, 1, 1, 1, 1, 1};

    private static int GetNbOfPointsToAllocateForLevel(int level)
    {
      return level * STAT_BONUS_BY_LEVEL;
    }

    public static Character CreateStartingCharacterByType(CharacterType characterType)
    {
        int[] baseStats = new int[9];
        Weapon weapon = WeaponFactory.CreateStartingWeapon(WeaponType.NONE);

        switch (characterType)
        {
            case CharacterType.WIZARD:
                baseStats = wizardBaseStats;
                weapon = WeaponFactory.CreateStartingWeapon(WeaponType.INTELLIGENCE);
                break;
            case CharacterType.WARRIOR:
                baseStats = warriorBaseStats;
                weapon = WeaponFactory.CreateStartingWeapon(WeaponType.STRENGTH);
                break;
            case CharacterType.HUNTRESS:
                baseStats = huntressBaseStats;
                weapon = WeaponFactory.CreateStartingWeapon(WeaponType.DEXTERITY);
                break;
            case CharacterType.SKELETON:
                baseStats = skeletonBaseStats;
                weapon = WeaponFactory.CreateStartingWeapon(WeaponType.STRENGTH);
                break;
            case CharacterType.GOBLIN:
                baseStats = goblinBaseStats;
                weapon = WeaponFactory.CreateStartingWeapon(WeaponType.DEXTERITY);
                break;
            case CharacterType.FLYING_EYE:
                baseStats = flyingEyeBaseStats;
                weapon = WeaponFactory.CreateStartingWeapon(WeaponType.INTELLIGENCE);
                break;
        }

        CharacterStats characterStats = new CharacterStats(baseStats[0], baseStats[1], baseStats[2], baseStats[3], baseStats[4], baseStats[5], baseStats[6], baseStats[7], baseStats[8]);
        CharacterEquipementManager characterEquipementManager = new CharacterEquipementManager(
            EquipementFactory.CreateStartingEquipementWithType(EquipementType.HELMET),
            EquipementFactory.CreateStartingEquipementWithType(EquipementType.CHESTPIECE),
            EquipementFactory.CreateStartingEquipementWithType(EquipementType.GREAVES),
            EquipementFactory.CreateStartingEquipementWithType(EquipementType.BOOTS),
            EquipementFactory.CreateStartingEquipementWithType(EquipementType.NECKLACE),
            EquipementFactory.CreateStartingEquipementWithType(EquipementType.RING),
            weapon);
        GameObject characterGameObject = new GameObject("Character", typeof(Character));
        Character character = characterGameObject.GetComponent<Character>();
        character.GetComponent<Character>().SetStatsAndEquipment(characterStats, characterEquipementManager);
        return character;
    }

    public static Character CreateEnemy(int level)
    {
        int[] baseStats = new int[9];

        switch (Random.Range(0,3))
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
        CharacterEquipementManager characterEquipementManager = new CharacterEquipementManager(
            EquipementFactory.CreateNewEquipement(level, EquipementType.HELMET),
            EquipementFactory.CreateNewEquipement(level, EquipementType.CHESTPIECE),
            EquipementFactory.CreateNewEquipement(level, EquipementType.GREAVES),
            EquipementFactory.CreateNewEquipement(level, EquipementType.BOOTS),
            EquipementFactory.CreateNewEquipement(level, EquipementType.NECKLACE),
            EquipementFactory.CreateNewEquipement(level, EquipementType.RING),
            WeaponFactory.CreateNewWeapon(level));
        GameObject characterGameObject = new GameObject("Character", typeof(Character));
        Character character = characterGameObject.GetComponent<Character>();
        character.GetComponent<Character>().SetStatsAndEquipment(characterStats, characterEquipementManager);
        return character;
    }
  }
}