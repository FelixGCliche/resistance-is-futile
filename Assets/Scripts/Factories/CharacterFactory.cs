using Equipment;
using Stats;
using UnityEngine;

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

    public static Character CreateNewCharacterByType(int level, CharacterType characterType)
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
          weapon = WeaponFactory.CreateNewWeapon(level);
          break;
        case CharacterType.GOBLIN:
          baseStats = goblinBaseStats;
          weapon = WeaponFactory.CreateNewWeapon(level);
          break;
        case CharacterType.FLYING_EYE:
          baseStats = flyingEyeBaseStats;
          weapon = WeaponFactory.CreateNewWeapon(level);
          break;
      }

      for (int i = 0; i < GetNbOfPointsToAllocateForLevel(level); i++)
      {
        baseStats[Random.Range(0, 9)]++;
      }

      CharacterStats characterStats = new CharacterStats(baseStats[0], baseStats[1], baseStats[2], baseStats[3],
        baseStats[4], baseStats[5], baseStats[6], baseStats[7], baseStats[8]);
      CharacterEquipementManager characterEquipementManager = new CharacterEquipementManager(
        EquipementFactory.CreateStartingEquipementWithType(EquipementType.HELMET),
        EquipementFactory.CreateStartingEquipementWithType(EquipementType.CHESTPIECE),
        EquipementFactory.CreateStartingEquipementWithType(EquipementType.GREAVES),
        EquipementFactory.CreateStartingEquipementWithType(EquipementType.BOOTS),
        EquipementFactory.CreateStartingEquipementWithType(EquipementType.NECKLACE),
        EquipementFactory.CreateStartingEquipementWithType(EquipementType.RING),
        weapon);
      return new Character(characterStats, characterEquipementManager);
    }
  }
}