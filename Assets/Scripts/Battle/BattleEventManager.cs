using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq.Expressions;
using UnityEngine;

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
        for (int i = 4; i < 7; i++)
        {
            characters[i] = Instantiate(baseEnemy, Vector3.zero, Quaternion.identity);
            characters[i].playerId = i;
        }
        //Add character speed as parameter
        FillBattleQueue();
    }

    private void FillBattleQueue(int CharacterOneSpeed = 0, int CharacterTwoSpeed = 0, int CharacterThreeSpeed = 0,
                                 int CharacterFourSpeed = 0, int CharacterFiveSpeed = 0, int CharacterSixSpeed = 0)
    {
        //Need to add priority system
        battleQueue.Add(1);
        battleQueue.Add(2);
        battleQueue.Add(3);
        battleQueue.Add(4);
        battleQueue.Add(5);
        battleQueue.Add(6);
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