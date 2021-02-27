using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vitality : MonoBehaviour
{
    [SerializeField] private int maxHealth = 10;

    private int health;
    
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReceiveAttack(Attack attack)
    {
        health -= attack.damageValue;
        
        if (health <= 0)
        {
            //Need to kill player
            health = 0;
            Debug.Log(attack.target + " is dead");
        }
        
        Debug.Log("Player " + attack.target + " health : " + health + "/" + maxHealth);
    }

    public void Heal(int value)
    {
        health += value;
        
        if (health >= maxHealth)
        {
            health = maxHealth;
        }
            
    }
}
