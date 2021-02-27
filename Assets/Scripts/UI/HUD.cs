
using System;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private HealthBar healthBar;
    
    private Character[] characters;
    
    
    private void Awake()
    {
        characters = GetComponents<Character>();
        GameObject newHealthBars = Instantiate(healthBar.gameObject);

        
        foreach (var character in characters)
        {
            
        }
    }
}
