using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Character character;
    private Slider healthSlider;
    private TextMeshPro healthText;
    private int maxHealth;

    private void Awake()
    {
        healthSlider = GetComponent<Slider>();
        healthText = GetComponentInChildren<TextMeshPro>();
    }

    void Start()
    {
        maxHealth = character.Stats.MaxVitality;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = character.Stats.Vitality;
    }

    private void Update()
    {
        healthSlider.value = character.Stats.Vitality;
        //healthText.text = character.Stats.Vitality + " / " + maxHealth;
    }
}
