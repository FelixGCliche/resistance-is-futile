using System;
using Battle;
using TMPro;
using UnityEngine;

namespace UI
{
  public class LevelTextUpdater : MonoBehaviour
  {
    private TextMeshProUGUI levelText;

    private void Awake()
    {
      levelText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
      levelText.text = String.Format("LV: {0}", BattleEventManager.Current.Level);
    }
  }
}