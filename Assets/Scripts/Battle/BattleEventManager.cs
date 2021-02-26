using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class BattleEventManager : MonoBehaviour
{
    public static BattleEventManager current;

    private void Awake()
    {
        current = this;
    }

    public event Action<Attack> onAttack;

    public void OnAttack(Attack attack)
    {
        if (onAttack != null)
            onAttack(attack);
    }
}
