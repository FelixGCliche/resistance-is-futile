using System;
using Battle;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
  [RequireComponent(typeof(Slider))]
  [RequireComponent(typeof(TextMeshProUGUI))]
  public class ExperienceBar : MonoBehaviour
  {
    private Slider experienceSlider;
    private TextMeshProUGUI experienceText;
    
    private int currentExperienceTreshold = BattleEventManager.Current.CurrentExperienceTreshold;
    private int experience = BattleEventManager.Current.Experience;

    private void Awake()
    {
      experienceSlider = GetComponent<Slider>();
      experienceText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
      experienceSlider.value = experience;
      experienceText.text = String.Format("{0}/{1} EXP", experience, currentExperienceTreshold);
    }
  }
}