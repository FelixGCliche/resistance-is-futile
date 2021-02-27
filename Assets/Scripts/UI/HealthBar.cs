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

    private void Awake()
    {
        healthSlider = GetComponent<Slider>();
        healthText = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Start()
    {
        maxHealth = character.Stats.MaxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = character.Stats.Health;
    }

    private void Update()
    {
        healthSlider.value = character.Stats.Health;
        healthText.text = character.Stats.Health + " / " + maxHealth;
    }
}
