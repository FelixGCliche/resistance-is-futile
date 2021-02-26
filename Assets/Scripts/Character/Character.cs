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
    [SerializeField] private KeyCode attackKey = KeyCode.Q;

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
        if (Input.GetKeyDown(attackKey))
        {
            AttackCharacter(1);
        }
    }

    private void onAttack(Attack attack)
    {
        if (attack.target == playerId)
            vitality.ReceiveAttack(attack);
    }

    void AttackCharacter(int target)
    {
        Attack attack = new Attack(target, damage.getDamage());
        BattleEventManager.current.OnAttack(attack);
    }
}
