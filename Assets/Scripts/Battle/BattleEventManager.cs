using System;
using System.Collections;
using System.Collections.Generic;
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
        private BattleQueue battleQueue;
        private bool isWaitingBetweenAttacks;

        private void Awake()
        {
            Current = this;
            characters = new Character[6];
            battleQueue = new BattleQueue(characters);
            isWaitingBetweenAttacks = false;
        }

        private void Start()
        {
            NewBattle();
        }

        public event Action<Attack, bool> onAttack;

        public void OnAttack(Attack attack)
        {
            onAttack?.Invoke(attack, IsCriticalHit());
            StartCoroutine(WaitForAttackToEnd());
        }

        private IEnumerator WaitForAttackToEnd()
        {
            isWaitingBetweenAttacks = true;
            yield return new WaitForSeconds(timeBetweenAttackInSeconds);
            isWaitingBetweenAttacks = false;
            battleQueue.EndTurn();
        }

        private void NewBattle()
        {
            for (int i = 3; i < 6; i++)
            {
                characters[i] = Instantiate(baseEnemy, Vector3.zero, Quaternion.identity);
                characters[i].playerId = i;
            }
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