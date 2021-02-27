using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class BattleEventManager : MonoBehaviour
{
    //To remove once we have a factory
    [SerializeField] private Character baseEnemy;
    
    public static BattleEventManager current;
    
    public Character[] players;
    private Character[] enemies;
    private List<int> battleQueue;

    private void Awake()
    {
        current = this;
        players = new Character[3];
        enemies = new Character[3];
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
        for (int i = 0; i < 3; i++)
        {
            enemies[i] = Instantiate(baseEnemy, Vector3.zero, Quaternion.identity);
            enemies[i].playerId = i + 4;
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
}