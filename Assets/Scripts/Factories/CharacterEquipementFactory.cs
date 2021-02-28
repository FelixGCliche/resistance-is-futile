using Stats;
using System;
using UnityEngine;
using Random = UnityEngine.Random;
using Equipment;

namespace Factory
{
    class CharacterEquipementFactory
    {
        public static CharacterEquipementManager CreateStartingCharacterEquipementByType(CharacterType characterType)
        {

            Weapon weapon = WeaponFactory.CreateStartingWeapon(WeaponType.NONE);

            switch (characterType)
            {
                case CharacterType.WIZARD:
                    weapon = WeaponFactory.CreateStartingWeapon(WeaponType.INTELLIGENCE);
                    break;
                case CharacterType.WARRIOR:
                    weapon = WeaponFactory.CreateStartingWeapon(WeaponType.STRENGTH);
                    break;
                case CharacterType.HUNTRESS:
                    weapon = WeaponFactory.CreateStartingWeapon(WeaponType.DEXTERITY);
                    break;
                case CharacterType.SKELETON:
                    weapon = WeaponFactory.CreateStartingWeapon(WeaponType.STRENGTH);
                    break;
                case CharacterType.GOBLIN:
                    weapon = WeaponFactory.CreateStartingWeapon(WeaponType.DEXTERITY);
                    break;
                case CharacterType.FLYING_EYE:
                    weapon = WeaponFactory.CreateStartingWeapon(WeaponType.INTELLIGENCE);
                    break;
            }

            CharacterEquipementManager characterEquipementManager = new CharacterEquipementManager(
                EquipementFactory.CreateStartingEquipementWithType(EquipementType.HELMET),
                EquipementFactory.CreateStartingEquipementWithType(EquipementType.CHESTPIECE),
                EquipementFactory.CreateStartingEquipementWithType(EquipementType.GREAVES),
                EquipementFactory.CreateStartingEquipementWithType(EquipementType.BOOTS),
                EquipementFactory.CreateStartingEquipementWithType(EquipementType.NECKLACE),
                EquipementFactory.CreateStartingEquipementWithType(EquipementType.RING),
                weapon);
            return characterEquipementManager;
        }

        public static CharacterEquipementManager CreateEnemyEquipement(int level)
        {
            switch (Random.Range(0, 3))
            {
                case 0:
                    //Skeleton
                    break;
                case 1:
                    //Goblin
                    break;
                case 2:
                    //Flying_Eye
                    break;
            }
            CharacterEquipementManager characterEquipementManager = new CharacterEquipementManager(
                EquipementFactory.CreateNewEquipement(level, EquipementType.HELMET),
                EquipementFactory.CreateNewEquipement(level, EquipementType.CHESTPIECE),
                EquipementFactory.CreateNewEquipement(level, EquipementType.GREAVES),
                EquipementFactory.CreateNewEquipement(level, EquipementType.BOOTS),
                EquipementFactory.CreateNewEquipement(level, EquipementType.NECKLACE),
                EquipementFactory.CreateNewEquipement(level, EquipementType.RING),
                WeaponFactory.CreateNewWeapon(level));
            return characterEquipementManager;
        }
    }
}
