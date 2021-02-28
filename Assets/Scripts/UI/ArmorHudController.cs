using Equipment;
using TMPro;
using UnityEngine;

namespace UI
{
  public class ArmorHudController : MonoBehaviour
  {
    [SerializeField] private DamageType type = DamageType.NONE;

    private CharacterHudController characterHudController;
    private TextMeshProUGUI armorValue;

    private void Start()
    {
      armorValue = GetComponentInChildren<TextMeshProUGUI>();
      characterHudController = GetComponentInParent<CharacterHudController>();
    }

    private void Update()
    {
      if (armorValue != null)
      {
        switch (type)
        {
          case DamageType.PHYSICAL:
            armorValue.text = characterHudController.Character.Stats.PhysicalArmor.ToString();
            break;
          case DamageType.MAGIC:
            armorValue.text = characterHudController.Character.Stats.MagicArmor.ToString();
            break;
        }
      }
    }
  }
}