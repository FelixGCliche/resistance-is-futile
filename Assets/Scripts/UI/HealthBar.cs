using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
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
    }

    void Start()
    {
      StartCoroutine(LateStart());
    }

    private void Update()
    {
      currentHealth = character.Stats.Health;
      healthSlider.value = currentHealth;
      healthText.text = currentHealth + " / " + maxHealth;
    }

    private IEnumerator LateStart()
    {
      yield return new WaitUntil(() => character.Stats != null);
      currentHealth = character.Stats.Health;
      maxHealth = character.Stats.MaxHealth;
      healthSlider.maxValue = maxHealth;
      healthSlider.value = currentHealth;
    }
  }
}