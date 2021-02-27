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

    private int equipementSpeedBoost;
    private int equipementStrengthBoost;
    private int equipementDexterityBoost;
    private int equipementIntelligenceBoost;
    private float equipementCriticalChanceBoost;
    private float equipementDodgeChanceBoost;
    private int equipementPhysicalArmorBoost;
    private int equipementMagicArmorBoost;

    public int EquipementSpeedBoost => equipementSpeedBoost;
    public int EquipementStrengthBoost => equipementStrengthBoost;
    public int EquipementDexterityBoost => equipementDexterityBoost;
    public int EquipementIntelligenceBoost => equipementIntelligenceBoost;
    public float EquipementCriticalChanceBoost => equipementCriticalChanceBoost;
    public float EquipementDodgeChanceBoost => equipementDodgeChanceBoost;
    public int EquipementPhysicalArmorBoost => equipementPhysicalArmorBoost;
    public int EquipementMagicArmorBoost => equipementMagicArmorBoost;

    public void SwapEquipement(IEquippable newEquippable)
    {
      switch (newEquippable.Type)
      {
        case EquipementType.HELMET:
          helmet = newEquippable;
          UpdateBoosts();
          break;
        case EquipementType.CHESTPIECE:
          chestPiece = newEquippable;
          UpdateBoosts();
          break;
        case EquipementType.GREAVES:
          greaves = newEquippable;
          UpdateBoosts();
          break;
        case EquipementType.BOOTS:
          boots = newEquippable;
          UpdateBoosts();
          break;
        case EquipementType.NECKLACE:
          necklace = newEquippable;
          UpdateBoosts();
          break;
        case EquipementType.RING:
          ring = newEquippable;
          UpdateBoosts();
          break;
        case EquipementType.WEAPON:
          weapon = (IWeapon) newEquippable;
          UpdateBoosts();
          break;
      }
    }

    private void UpdateBoosts()
    {
      GetEquipementSpeedBoost();
      GetEquipementDexterityBoost();
      GetEquipementStrengthBoost();
      GetEquipementIntelligenceBoost();
      GetEquipementDodgeChanceBoost();
      GetEquipementCriticalChanceBoost();
      GetEquipementPhysicalArmorBoost();
      GetEquipementMagicArmorBoost();
    }

    public void GetEquipementSpeedBoost()
    {
      equipementSpeedBoost = helmet.SpeedBoost + 
             chestPiece.SpeedBoost + 
             greaves.SpeedBoost + 
             boots.SpeedBoost + 
             necklace.SpeedBoost +
             ring.SpeedBoost +
             weapon.SpeedBoost;
    }

    public void GetEquipementStrengthBoost()
    {
      equipementStrengthBoost = helmet.StrengthBoost + 
             chestPiece.StrengthBoost + 
             greaves.StrengthBoost + 
             boots.StrengthBoost + 
             necklace.StrengthBoost +
             ring.StrengthBoost +
             weapon.StrengthBoost;
    }

    public void GetEquipementDexterityBoost()
    {
      equipementDexterityBoost = helmet.DexterityBoost + 
             chestPiece.DexterityBoost + 
             greaves.DexterityBoost + 
             boots.DexterityBoost + 
             necklace.DexterityBoost +
             ring.DexterityBoost +
             weapon.DexterityBoost;
    }

    public void GetEquipementIntelligenceBoost()
    {
      equipementIntelligenceBoost = helmet.IntelligenceBoost + 
             chestPiece.IntelligenceBoost + 
             greaves.IntelligenceBoost + 
             boots.IntelligenceBoost + 
             necklace.IntelligenceBoost +
             ring.IntelligenceBoost +
             weapon.IntelligenceBoost;
    }

    public void GetEquipementDodgeChanceBoost()
    {
      equipementDodgeChanceBoost = helmet.DodgeChanceBoost + 
             chestPiece.DodgeChanceBoost + 
             greaves.DodgeChanceBoost + 
             boots.DodgeChanceBoost + 
             necklace.DodgeChanceBoost +
             ring.DodgeChanceBoost +
             weapon.DodgeChanceBoost;
    }

    public void GetEquipementCriticalChanceBoost()
    {
      equipementCriticalChanceBoost = helmet.CriticalChanceBoost + 
             chestPiece.CriticalChanceBoost + 
             greaves.CriticalChanceBoost + 
             boots.CriticalChanceBoost + 
             necklace.CriticalChanceBoost +
             ring.CriticalChanceBoost +
             weapon.CriticalChanceBoost;
    }

    public void GetEquipementPhysicalArmorBoost()
    {
      equipementPhysicalArmorBoost = helmet.PhysicalArmorBoost + 
             chestPiece.PhysicalArmorBoost + 
             greaves.PhysicalArmorBoost + 
             boots.PhysicalArmorBoost + 
             necklace.PhysicalArmorBoost +
             ring.PhysicalArmorBoost +
             weapon.PhysicalArmorBoost;
    }

    public void GetEquipementMagicArmorBoost()
    {
      equipementMagicArmorBoost = helmet.MagicArmorBoost+ 
             chestPiece.MagicArmorBoost+ 
             greaves.MagicArmorBoost+ 
             boots.MagicArmorBoost+ 
             necklace.MagicArmorBoost+
             ring.MagicArmorBoost+
             weapon.MagicArmorBoost;
    }
  }
}