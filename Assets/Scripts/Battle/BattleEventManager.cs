using System;
using System.Collections;
using Factory;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Battle
{
    public class BattleEventManager : MonoBehaviour
    {
        [SerializeField] [Min(0)]
        private int levelUpMultiplier = 100;
        [SerializeField] [Min(0)]
        private int baseExperienceGain = 100;
        [SerializeField] [Range(0.0f, 1.0f)]
        private float battleExperienceMultiplier = 0.1f;
        
        [SerializeField] private float timeBetweenAttackInSeconds = 2f;
        
        private BattleQueue battleQueue;
        private bool isWaitingBetweenAttacks;
        private int experience = 0;
        private int level = 0;

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
            CreateCharacters();
            NewBattle();
            isWaitingBetweenAttacks = false;
        }

        private void CreateCharacters()
        {
            characters[0] = CharacterFactory.CreateStartingCharacterByType(CharacterType.WARRIOR);
            characters[0].playerId = 0;
            characters[1] = CharacterFactory.CreateStartingCharacterByType(CharacterType.HUNTRESS);
            characters[1].playerId = 1;
            characters[2] = CharacterFactory.CreateStartingCharacterByType(CharacterType.WIZARD);
            characters[2].playerId = 2;
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
                            characters[i].OnDefend(attack, IsCriticalHit());
                        }
                    }
                    else
                    {
                        for (int i = 3; i < 6; i++)
                        {
                            characters[i].OnDefend(attack, IsCriticalHit());
                        }
                    }
                    break;
                case AttackType.SPLASH:
                    characters[attack.Target].OnDefend(attack, IsCriticalHit());
                    if (attack.Target != 0 && attack.Target != 3)
                        characters[attack.Target-1].OnDefend(attack, IsCriticalHit());
                    if (attack.Target != 2 && attack.Target != 5)
                        characters[attack.Target+1].OnDefend(attack, IsCriticalHit());
                    break;
                case AttackType.SPLASH_UP:
                    characters[attack.Target].OnDefend(attack, IsCriticalHit());
                    if (attack.Target != 0 && attack.Target != 3)
                        characters[attack.Target-1].OnDefend(attack, IsCriticalHit());
                    break;
                case AttackType.SPLASH_DOWN:
                    characters[attack.Target].OnDefend(attack, IsCriticalHit());
                    if (attack.Target != 2 && attack.Target != 5)
                        characters[attack.Target+1].OnDefend(attack, IsCriticalHit());
                    break;
            }
            StartCoroutine(WaitForAttackToEnd());
        }

        private IEnumerator WaitForAttackToEnd()
        {
            yield return new WaitForSeconds(timeBetweenAttackInSeconds);
            battleQueue.EndTurn();
            StartCoroutine(battleQueue.GetCurrentCharacter().Attack());
        }

        private void NewBattle()
        {
            for (int i = 3; i < 6; i++)
            {
                characters[i] = CharacterFactory.CreateEnemy(1);
                characters[i].playerId = i;
            }
            battleQueue = new BattleQueue(characters);
            StartCoroutine(battleQueue.GetCurrentCharacter().Attack());
        }

        private void EndBattle()
        {
            //Do loot drop
        
            GainExperience();
            DestroyEnemies();
            NewBattle();
        }

        private void EndGame()
        {
            //End game
        }

        private void DestroyEnemies()
        {
            Destroy(characters[3]);
            characters[3] = null;
            Destroy(characters[4]);
            characters[4] = null;
            Destroy(characters[5]);
            characters[5] = null;
        }

        private bool IsCriticalHit()
        {
            return Random.Range(0.0f, 100.0f) <= battleQueue.GetCurrentCharacter().Stats.CriticalChance;
        }

        private void GainExperience()
        {
            int totalExperineceGain = baseExperienceGain + Mathf.CeilToInt(baseExperienceGain * battleExperienceMultiplier * level);
            experience += totalExperineceGain;
        }
    }
}