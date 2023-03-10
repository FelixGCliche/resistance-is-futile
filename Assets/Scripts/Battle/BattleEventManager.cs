using System;
using System.Collections;
using Equipment;
using Factory;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Battle
{
    public class BattleEventManager : MonoBehaviour
    {
        [SerializeField] [Min(0)] private int levelUpMultiplier = 100;
        [SerializeField] [Min(0)] private int baseExperienceGain = 100;
        [SerializeField] [Range(0.0f, 1.0f)] private float battleExperienceMultiplier = 0.1f;
        [SerializeField] private float timeBetweenAttackInSeconds = 1f;

        private BattleQueue battleQueue;
        private bool isWaitingBetweenAttacks;
        private int experience = 0;
        private int level = 1;

        public static BattleEventManager Current;

        public Character[] characters;
        public Character currentCharacter => battleQueue.GetCurrentCharacter();

        public int Experience => experience;
        public int Level => level;

        public int CurrentExperienceTreshold => level * levelUpMultiplier;

        private void Awake()
        {
            Current = this;
            characters = new Character[6];
            isWaitingBetweenAttacks = false;
            StartCoroutine(WaitForCharacterCreation());
        }

        private IEnumerator WaitForCharacterCreation()
        {
            yield return new WaitUntil(() => characters[0] != null &&
                                             characters[1] != null &&
                                             characters[2] != null &&
                                             characters[3] != null &&
                                             characters[4] != null &&
                                             characters[5] != null);
            CreateCharacters();
            NewBattle();
        }

        private void CreateCharacters()
        {
            characters[0].SetStatsAndEquipment(StatsFactory.CreateStartingCharacterStatsByType(CharacterType.WIZARD),
                CharacterEquipementFactory.CreateStartingCharacterEquipementByType(CharacterType.WIZARD));
            characters[1].SetStatsAndEquipment(StatsFactory.CreateStartingCharacterStatsByType(CharacterType.WARRIOR),
                CharacterEquipementFactory.CreateStartingCharacterEquipementByType(CharacterType.WARRIOR));
            characters[2].SetStatsAndEquipment(StatsFactory.CreateStartingCharacterStatsByType(CharacterType.HUNTRESS),
                CharacterEquipementFactory.CreateStartingCharacterEquipementByType(CharacterType.HUNTRESS));
        }

        public void OnAttack(Attack attack)
        {
            switch (attack.AttackType)
            {
                case AttackType.SINGLE_TARGET:
                    characters[attack.Target].OnDefend(attack, IsCriticalHit());
                    break;
                case AttackType.AOE:
                    if (attack.Target < 3)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (!characters[i].IsDead)
                                characters[i].OnDefend(attack, IsCriticalHit());
                        }
                    }
                    else
                    {
                        for (int i = 3; i < 6; i++)
                        {
                            if (!characters[i].IsDead)
                                characters[i].OnDefend(attack, IsCriticalHit());
                        }
                    }

                    break;
                case AttackType.SPLASH:
                    characters[attack.Target].OnDefend(attack, IsCriticalHit());
                    if (attack.Target != 0 && attack.Target != 3 && !characters[attack.Target - 1].IsDead)
                        characters[attack.Target - 1].OnDefend(attack, IsCriticalHit());
                    if (attack.Target != 2 && attack.Target != 5 && !characters[attack.Target + 1].IsDead)
                        characters[attack.Target + 1].OnDefend(attack, IsCriticalHit());
                    break;
                case AttackType.SPLASH_UP:
                    characters[attack.Target].OnDefend(attack, IsCriticalHit());
                    if (attack.Target != 0 && attack.Target != 3 && !characters[attack.Target - 1].IsDead)
                        characters[attack.Target - 1].OnDefend(attack, IsCriticalHit());
                    break;
                case AttackType.SPLASH_DOWN:
                    characters[attack.Target].OnDefend(attack, IsCriticalHit());
                    if (attack.Target != 2 && attack.Target != 5 && !characters[attack.Target + 1].IsDead)
                        characters[attack.Target + 1].OnDefend(attack, IsCriticalHit());
                    break;
            }

            StartCoroutine(WaitForAttackToEnd());
        }

        private IEnumerator WaitForAttackToEnd()
        {
            yield return new WaitForSeconds(timeBetweenAttackInSeconds);
            battleQueue.EndTurn();
            Character currentAttacker = battleQueue.GetCurrentCharacter();
            if (currentAttacker != null)
                StartCoroutine(currentAttacker.Attack());
        }

        private void NewBattle()
        {
            for (int i = 3; i < 6; i++)
            {
                characters[i].SetStatsAndEquipment(StatsFactory.CreateEnemyStats(level),
                    CharacterEquipementFactory.CreateEnemyEquipement(level));
            }

            battleQueue = new BattleQueue(characters);
            StartCoroutine(battleQueue.GetCurrentCharacter().Attack());
        }

        public void VerifyBattleEnd()
        {
            if (characters[0].IsDead && characters[1].IsDead && characters[2].IsDead)
                EndGame();
            else if (characters[3].IsDead && characters[4].IsDead && characters[5].IsDead)
                StartCoroutine(EndBattle());
        }

        private IEnumerator EndBattle()
        {
            battleQueue.StopQueue();
            GainExperience();
            
            Equipement[] drops = new Equipement[3];
            for (int i = 0; i < 3; i++)
            {
                EquipementType type = (EquipementType) Random.Range(0, 7);
                if (type == EquipementType.WEAPON)
                    drops[i] = WeaponFactory.CreateNewWeapon(level);
                else
                    drops[i] = EquipementFactory.CreateNewEquipement(level, type);
            }
            
            SwitchWeaponMenu.Current.ActivateSwitchWeaponMenu();
            
            for (int i = 0; i < 3; i++)
            {
                SwitchWeaponMenu.Current.GetNewCards(drops[i]);
                Debug.Log("What do you want to do with : " + drops[i].Type);
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Alpha1) ||
                                                 Input.GetKeyDown(KeyCode.Alpha2) ||
                                                 Input.GetKeyDown(KeyCode.Alpha3) ||
                                                 Input.GetKeyDown(KeyCode.Alpha4));
                    if (Input.GetKeyDown(KeyCode.Alpha1))
                    {
                        Debug.Log("Equipped on player 0");
                        characters[0].CurrentEquipement.SwapEquipement(drops[i]);
                        yield return new WaitForSeconds(1f);
                    }
                    else if (Input.GetKeyDown(KeyCode.Alpha2))
                    {
                        Debug.Log("Equipped on player 1");
                        characters[1].CurrentEquipement.SwapEquipement(drops[i]);
                        yield return new WaitForSeconds(1f);
                    }
                    else if (Input.GetKeyDown(KeyCode.Alpha3))
                    {
                        Debug.Log("Equipped on player 2");
                        characters[2].CurrentEquipement.SwapEquipement(drops[i]);
                        yield return new WaitForSeconds(1f);
                    }
                    else if (Input.GetKeyDown(KeyCode.Alpha4))
                    {
                        Debug.Log("Equippement discarded");
                        yield return new WaitForSeconds(1f);
                    }
                    
                    yield return new WaitForSecondsRealtime(0.2f);
            }

            ResetCharacters();
            NewBattle();
            SwitchWeaponMenu.Current.DeactivateSwitchWeaponMenu();
        }

        private void EndGame()
        {
            DeathScreen.Current.ActivateDeathScreen();
        }

        private bool IsCriticalHit()
        {
            return Random.Range(0.0f, 100.0f) <= battleQueue.GetCurrentCharacter().Stats.CriticalChance;
        }

        private void GainExperience()
        {
            int totalExperineceGain = baseExperienceGain +
                                      Mathf.CeilToInt(baseExperienceGain * battleExperienceMultiplier * level);
            experience += totalExperineceGain;
            if (experience >= CurrentExperienceTreshold)
            {
                experience -= CurrentExperienceTreshold;
                level++;
            }
        }

        private void ResetCharacters()
        {
            foreach (var character in characters)
            {
                character.Stats.FullHeal();
                character.ResetAnimation();
            }
        }
    }
}