using UnityEngine;

namespace Equipment
{
  public class CharacterEquipementManager : MonoBehaviour
  {
    private IEquippable helmet;
    private IEquippable chestPiece;
    private IEquippable greaves;
    private IEquippable boots;
    private IEquippable necklace;
    private IEquippable ring;
    private IWeapon weapon;

    public void SwapEquipement(IEquippable newEquippable)
    {
      switch (newEquippable.Type)
      {
        case EquipementType.HELMET:
          helmet = newEquippable;
          break;
        case EquipementType.CHESTPIECE:
          chestPiece = newEquippable;
          break;
        case EquipementType.GREAVES:
          greaves = newEquippable;
          break;
        case EquipementType.BOOTS:
          boots = newEquippable;
          break;
        case EquipementType.NECKLACE:
          necklace = newEquippable;
          break;
        case EquipementType.RING:
          ring = newEquippable;
          break;
        case EquipementType.WEAPON:
          weapon = (IWeapon) newEquippable;
          break;
      }
    }

    public int GetEquipementSpeedBoost()
    {
      return helmet.SpeedBoost + 
             chestPiece.SpeedBoost + 
             greaves.SpeedBoost + 
             boots.SpeedBoost + 
             necklace.SpeedBoost +
             ring.SpeedBoost +
             weapon.SpeedBoost;
    }

    public int GetEquipementStrengthBoost()
    {
      return helmet.StrengthBoost + 
             chestPiece.StrengthBoost + 
             greaves.StrengthBoost + 
             boots.StrengthBoost + 
             necklace.StrengthBoost +
             ring.StrengthBoost +
             weapon.StrengthBoost;
    }

    public int GetEquipementDexterityBoost()
    {
      return helmet.DexterityBoost + 
             chestPiece.DexterityBoost + 
             greaves.DexterityBoost + 
             boots.DexterityBoost + 
             necklace.DexterityBoost +
             ring.DexterityBoost +
             weapon.DexterityBoost;
    }

    public int GetEquipementIntelligenceBoost()
    {
      return helmet.IntelligenceBoost + 
             chestPiece.IntelligenceBoost + 
             greaves.IntelligenceBoost + 
             boots.IntelligenceBoost + 
             necklace.IntelligenceBoost +
             ring.IntelligenceBoost +
             weapon.IntelligenceBoost;
    }

    public int GetEquipementDodgeChanceBoost()
    {
      return helmet.DodgeChanceBoost + 
             chestPiece.DodgeChanceBoost + 
             greaves.DodgeChanceBoost + 
             boots.DodgeChanceBoost + 
             necklace.DodgeChanceBoost +
             ring.DodgeChanceBoost +
             weapon.DodgeChanceBoost;
    }

    public int GetEquipementCriticalChanceBoost()
    {
      return helmet.CriticalChanceBoost + 
             chestPiece.CriticalChanceBoost + 
             greaves.CriticalChanceBoost + 
             boots.CriticalChanceBoost + 
             necklace.CriticalChanceBoost +
             ring.CriticalChanceBoost +
             weapon.CriticalChanceBoost;
    }

    public int GetEquipementPhysicalArmorBoost()
    {
      return helmet.PhysicalArmorBoost + 
             chestPiece.PhysicalArmorBoost + 
             greaves.PhysicalArmorBoost + 
             boots.PhysicalArmorBoost + 
             necklace.PhysicalArmorBoost +
             ring.PhysicalArmorBoost +
             weapon.PhysicalArmorBoost;
    }

    public int GetEquipementMagicArmorBoost()
    {
      return helmet.MagicArmorBoost+ 
             chestPiece.MagicArmorBoost+ 
             greaves.MagicArmorBoost+ 
             boots.MagicArmorBoost+ 
             necklace.MagicArmorBoost+
             ring.MagicArmorBoost+
             weapon.MagicArmorBoost;
    }
  }
}