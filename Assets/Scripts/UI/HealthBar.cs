using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
  public class HealthBar : MonoBehaviour
  {
    private CharacterHudController characterHudController;
    private Slider healthSlider;
    private TextMeshProUGUI healthText;

    private void Awake()
    {
      characterHudController = GetComponentInParent<CharacterHudController>();
      healthSlider = GetComponent<Slider>();
      healthText = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
      if (characterHudController.Character.Stats != null)
      {
        healthSlider.maxValue = characterHudController.Character.Stats.MaxHealth;

        healthSlider.value = characterHudController.Character.Stats.Health;
        healthText.text = characterHudController.Character.Stats.Health + " / " +
                          characterHudController.Character.Stats.MaxHealth;
      }
    }
  }
}