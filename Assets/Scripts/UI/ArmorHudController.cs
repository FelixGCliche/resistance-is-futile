using System;
using TMPro;
using UnityEngine;

namespace UI
{
  public class ArmorHudController : MonoBehaviour
  {
    private CharacterHudController characterHudController;

    [SerializeField] private TextMeshProUGUI armorValue;

    private void Awake()
    {
      characterHudController = GetComponentInParent<CharacterHudController>();
    }

    private void Update()
    {
      if (armorValue != null)
        armorValue.text = String.Format("{0} PHYSICAL : {1} MAGIC",
          characterHudController.Character.Stats.PhysicalArmor,
          characterHudController.Character.Stats.MagicArmor);
    }
  }
}