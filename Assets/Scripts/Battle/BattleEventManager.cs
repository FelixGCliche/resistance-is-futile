using System;
using System.Collections;
using Factory;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Battle
{
    public class BattleEventManager : MonoBehaviour
    {
        //To remove once we have a factory
        [SerializeField] private Character baseEnemy;
        [SerializeField] private float timeBetweenAttackInSeconds = 2f;
    
        public static BattleEventManager Current;
    
        public Character[] characters;
        public Character currentCharacter => battleQueue.GetCurrentCharacter();
        
        private BattleQueue battleQueue;
        private bool isWaitingBetweenAttacks;

        private void Awake()
        {
            characters = new Character[6];
            CreateCharacters();
            NewBattle();
            isWaitingBetweenAttacks = false;
            Current = this;
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

        public event Action<Attack, bool> onAttack;

        public void OnAttack(Attack attack)
        {
            characters[attack.Target].OnDefend(attack, IsCriticalHit());
            //onAttack?.Invoke(attack, IsCriticalHit());
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
    }
}