using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class BattleEventManager : MonoBehaviour
{
    public static BattleEventManager current;

    private List<int> battleQueue;

    private void Awake()
    {
        current = this;
        battleQueue = new List<int>();
        FillBattleQueue();
    }

    public event Action<Attack> onAttack;

    public void OnAttack(Attack attack)
    {
        onAttack?.Invoke(attack);
        battleQueue.Add(battleQueue[0]);
        battleQueue.Remove(0);
    }

    private void FillBattleQueue(int CharacterOneSpeed = 0, int CharacterTwoSpeed = 0, int CharacterThreeSpeed = 0,
                                 int CharacterFourSpeed = 0, int CharacterFiveSpeed = 0, int CharacterSixSpeed = 0)
    {
        battleQueue.Add(1);
        battleQueue.Add(2);
    }

    public int GetCurrentAttackerId()
    {
        return battleQueue[0];
    }
}