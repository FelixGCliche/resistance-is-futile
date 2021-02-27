using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq.Expressions;
using UnityEngine;
using Random = UnityEngine.Random;

public class BattleEventManager : MonoBehaviour
{
    //To remove once we have a factory
    [SerializeField] private Character baseEnemy;
    
    public static BattleEventManager current;
    
    public Character[] characters;
    private List<int> battleQueue;

    private void Awake()
    {
        current = this;
        characters = new Character[6];
        battleQueue = new List<int>();
    }

    private void Start()
    {
        NewBattle();
    }

    public event Action<Attack> onAttack;

    public void OnAttack(Attack attack)
    {
        onAttack?.Invoke(attack);
        battleQueue.Add(battleQueue[0]);
        battleQueue.RemoveAt(0);
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
        if(characters[0] != null && !characters[0].IsDead)
            battleQueue.Add(1);
        if(characters[1] != null && !characters[1].IsDead)
            battleQueue.Add(2);
        if(characters[2] != null && !characters[2].IsDead)
            battleQueue.Add(3);
        if(characters[3] != null && !characters[3].IsDead)
            battleQueue.Add(4);
        if(characters[4] != null && !characters[4].IsDead)
            battleQueue.Add(5);
        if(characters[5] != null && !characters[5].IsDead)
            battleQueue.Add(6);

        for (int i = 1; i < 6; i++)
        {
            int iSpeed = characters[battleQueue[i]-1].Stats.Speed;
            for (int j = i-1; j >= 0; j--)
            {
                int jSpeed = characters[battleQueue[j]-1].Stats.Speed;
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
        return battleQueue[0];
    }

    public void KillTarget(int target)
    {
        battleQueue.Remove(target - 1);
        characters[target-1].Die();
        
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
}