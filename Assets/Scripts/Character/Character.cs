using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private int level = 1;
    [SerializeField] private Vitality vitality;
    [SerializeField] private Damage damage;
    [SerializeField] private int playerId = 1;

    private void OnEnable()
    {
        BattleEventManager.current.onAttack += onAttack;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void onAttack(Attack attack)
    {
        if (attack.target == playerId)
            vitality.ReceiveAttack(attack);
    }

    private void Attack()
    {
        Attack attack = new Attack(1, damage.getDamage());
        BattleEventManager.current.OnAttack(attack);
    }
}
