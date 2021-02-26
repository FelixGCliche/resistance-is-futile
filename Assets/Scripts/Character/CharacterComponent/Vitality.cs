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
        
        Debug.Log(health);
        
        if (health <= 0)
        {
            Debug.Log("You are dead");
        }
            
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
