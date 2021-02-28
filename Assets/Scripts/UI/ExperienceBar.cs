using System;
using Battle;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
  public class ExperienceBar : MonoBehaviour
  {
    private Slider experienceSlider;
    private TextMeshProUGUI experienceText;

    private int currentExperienceTreshold;
    private int experience;

    private void Awake()
    {
      experienceSlider = GetComponent<Slider>();
      experienceText = GetComponentInChildren<TextMeshProUGUI>();
      
      experienceSlider.minValue = 0;
    }

    private void Start()
    {
      currentExperienceTreshold = BattleEventManager.Current.CurrentExperienceTreshold;
      experience = BattleEventManager.Current.Experience;
      experienceSlider.maxValue = currentExperienceTreshold;
    }

    private void Update()
    {
      experienceSlider.value = experience;
      experienceText.text = String.Format("{0}/{1} EXP", experience, currentExperienceTreshold);
    }
  }
}