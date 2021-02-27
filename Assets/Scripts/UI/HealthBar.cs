using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Character character;
    private Slider healthSlider;
    private TextMeshProUGUI healthText;
    private int maxHealth;
    private int currentHealth;

    private void Awake()
    {
        healthSlider = GetComponent<Slider>();
        healthText = GetComponentInChildren<TextMeshProUGUI>();
        currentHealth = character.Stats.Health;
    }

    void Start()
    {
        maxHealth = character.Stats.MaxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    private void Update()
    {
        healthSlider.value = currentHealth;
        healthText.text = currentHealth + " / " + maxHealth;
    }
}
