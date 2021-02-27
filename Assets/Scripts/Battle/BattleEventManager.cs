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
        [SerializeField] private GameCharacter.Character baseEnemy;
        [SerializeField] private float timeBetweenAttackInSeconds = 2f;
    
        public static BattleEventManager Current;
    
        public GameCharacter.Character[] characters;
        private List<int> battleQueue;
        private bool isWaitingBetweenAttacks;

        private void Awake()
        {
            Current = this;
            characters = new GameCharacter.Character[6];
            battleQueue = new List<int>();
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
            battleQueue.Add(battleQueue[0]);
            battleQueue.RemoveAt(0);
            StartCoroutine(WaitForAttackToEnd());
        }

        private IEnumerator WaitForAttackToEnd()
        {
            isWaitingBetweenAttacks = true;
            yield return new WaitForSeconds(timeBetweenAttackInSeconds);
            isWaitingBetweenAttacks = false;
        }

        private void NewBattle()
        {
            for (int i = 3; i < 6; i++)
            {
                characters[i] = Instantiate(baseEnemy, Vector3.zero, Quaternion.identity);
                characters[i].playerId = i;
            }
            //Add character speed as parameter
            FillBattleQueue();
        }

        private void FillBattleQueue()
        {
            for (int i = 0; i < 6; i++)
            {
                if(characters[i] != null && !characters[i].IsDead)
                    battleQueue.Add(i);
            }

            for (int i = 0; i < 3; i++)
            {
                int iSpeed = characters[battleQueue[i]].Stats.Speed;
                for (int j = i-1; j >= 0; j--)
                {
                    int jSpeed = characters[battleQueue[j]].Stats.Speed;
                    if (iSpeed > jSpeed || (iSpeed == jSpeed && Random.Range(1,3) == 1))
                    {
                        battleQueue.Insert(j, battleQueue[i]);
                        battleQueue.RemoveAt(i+1);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        public int GetCurrentAttackerId()
        {
            if (!isWaitingBetweenAttacks)
                return battleQueue[0];
            return -1;
        }

        public void KillTarget()
        {
            foreach (GameCharacter.Character character in characters)
            {
                if (character.IsDead)
                    battleQueue.Remove(character.playerId);
            }
        
            if(characters[3].IsDead && characters[4].IsDead && characters[5].IsDead)
                EndBattle();
            else if(characters[0].IsDead && characters[1].IsDead && characters[2].IsDead)
                EndGame();
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
            return Random.Range(0.0f, 100.0f) <= characters[GetCurrentAttackerId()].Stats.CriticalChance;
        }
    }
}