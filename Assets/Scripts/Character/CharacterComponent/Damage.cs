using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private int baseDamage = 4;

    private int damage;
    
    // Start is called before the first frame update
    void Start()
    {
        damage = baseDamage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
