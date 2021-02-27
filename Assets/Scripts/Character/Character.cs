using Equipment;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Random = UnityEngine.Random;

public class Character : MonoBehaviour
{
    [SerializeField] private int level = 1;
    [SerializeField] private Vitality vitality;
    [SerializeField] private Damage damage;
    [SerializeField] public int playerId = 1;
    [SerializeField] private bool isPlayer = true;

    private CharacterEquipementManager currentEquipement;

    // Start is called before the first frame update
    void Start()
    {
        if(isPlayer)
            BattleEventManager.current.players[playerId - 1] = this;
        BattleEventManager.current.onAttack += onAttack;
    }

    // Update is called once per frame
    void Update()
    {
        if (BattleEventManager.current.GetCurrentAttackerId() == playerId)
        {
            if (isPlayer)
            {
                //Adapt to different player attack
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    Debug.Log("Player " + playerId + " attacks player " + 4);
                    AttackCharacter(4);
                }
                else if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    Debug.Log("Player " + playerId + " attacks player " + 5);
                    AttackCharacter(5);
                }
                else if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    Debug.Log("Player " + playerId + " attacks player " + 6);
                    AttackCharacter(6);
                }
            }
            else
            {
                //Need enemy Ai
                Debug.Log("Player " + playerId + " attacks player " + 1);
                AttackCharacter(Random.Range(1, 3));
            }
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
