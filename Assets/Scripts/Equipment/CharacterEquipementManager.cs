using UnityEngine;

namespace Equipment
{
  public class CharacterEquipementManager : MonoBehaviour
  {
    private Equipement helmet;
    private Equipement chestPiece;
    private Equipement greaves;
    private Equipement boots;
    private Equipement necklace;
    private Equipement ring;
    private Weapon weapon;

    private int equipementSpeedBoost;
    private int equipementStrengthBoost;
    private int equipementDexterityBoost;
    private int equipementIntelligenceBoost;
    private int equipementCriticalChanceBoost;
    private int equipementDodgeChanceBoost;
    private int equipementPhysicalArmorBoost;
    private int equipementMagicArmorBoost;

    public int EquipementSpeedBoost => equipementSpeedBoost;
    public int EquipementStrengthBoost => equipementStrengthBoost;
    public int EquipementDexterityBoost => equipementDexterityBoost;
    public int EquipementIntelligenceBoost => equipementIntelligenceBoost;
    public int EquipementCriticalChanceBoost => equipementCriticalChanceBoost;
    public int EquipementDodgeChanceBoost => equipementDodgeChanceBoost;
    public int EquipementPhysicalArmorBoost => equipementPhysicalArmorBoost;
    public int EquipementMagicArmorBoost => equipementMagicArmorBoost;

    public Weapon Weapon => weapon;

    public CharacterEquipementManager(Equipement helmet, Equipement chestPiece, Equipement greaves, Equipement boots, Equipement necklace, Equipement ring, Weapon weapon)
    {
        this.helmet = helmet;
        this.chestPiece = chestPiece;
        this.greaves = greaves;
        this.boots = boots;
        this.necklace = necklace;
        this.ring = ring;
        this.weapon = weapon;
        UpdateBoosts();
    }

    public void SwapEquipement(Equipement newEquippable)
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
          weapon = (Weapon) newEquippable;
          UpdateBoosts();
          break;
      }
    }

    public void SwapEquipementWithoutStatUpdate(Equipement newEquippable)
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
          weapon = (Weapon) newEquippable;
          break;
      }
    }

    private void UpdateBoosts()
    {
      CalculateEquipementSpeedBoost();
      CalculateEquipementDexterityBoost();
      CalculateEquipementStrengthBoost();
      CalculateEquipementIntelligenceBoost();
      CalculateEquipementDodgeChanceBoost();
      CalculateGetEquipementCriticalChanceBoost();
      CalculateEquipementPhysicalArmorBoost();
      CalculateEquipementMagicArmorBoost();
    }

    private void CalculateEquipementSpeedBoost()
    {
      equipementSpeedBoost = helmet.SpeedBoost + 
             chestPiece.SpeedBoost + 
             greaves.SpeedBoost + 
             boots.SpeedBoost + 
             necklace.SpeedBoost +
             ring.SpeedBoost +
             weapon.SpeedBoost;
    }

    private void CalculateEquipementStrengthBoost()
    {
      equipementStrengthBoost = helmet.StrengthBoost + 
             chestPiece.StrengthBoost + 
             greaves.StrengthBoost + 
             boots.StrengthBoost + 
             necklace.StrengthBoost +
             ring.StrengthBoost +
             weapon.StrengthBoost;
    }

    private void CalculateEquipementDexterityBoost()
    {
      equipementDexterityBoost = helmet.DexterityBoost + 
             chestPiece.DexterityBoost + 
             greaves.DexterityBoost + 
             boots.DexterityBoost + 
             necklace.DexterityBoost +
             ring.DexterityBoost +
             weapon.DexterityBoost;
    }

    private void CalculateEquipementIntelligenceBoost()
    {
      equipementIntelligenceBoost = helmet.IntelligenceBoost + 
             chestPiece.IntelligenceBoost + 
             greaves.IntelligenceBoost + 
             boots.IntelligenceBoost + 
             necklace.IntelligenceBoost +
             ring.IntelligenceBoost +
             weapon.IntelligenceBoost;
    }

    private void CalculateEquipementDodgeChanceBoost()
    {
      equipementDodgeChanceBoost = helmet.DodgeChanceBoost + 
             chestPiece.DodgeChanceBoost + 
             greaves.DodgeChanceBoost + 
             boots.DodgeChanceBoost + 
             necklace.DodgeChanceBoost +
             ring.DodgeChanceBoost +
             weapon.DodgeChanceBoost;
    }

    private void CalculateGetEquipementCriticalChanceBoost()
    {
      equipementCriticalChanceBoost = helmet.CriticalChanceBoost + 
             chestPiece.CriticalChanceBoost + 
             greaves.CriticalChanceBoost + 
             boots.CriticalChanceBoost + 
             necklace.CriticalChanceBoost +
             ring.CriticalChanceBoost +
             weapon.CriticalChanceBoost;
    }

    private void CalculateEquipementPhysicalArmorBoost()
    {
      equipementPhysicalArmorBoost = helmet.PhysicalArmorBoost + 
             chestPiece.PhysicalArmorBoost + 
             greaves.PhysicalArmorBoost + 
             boots.PhysicalArmorBoost + 
             necklace.PhysicalArmorBoost +
             ring.PhysicalArmorBoost +
             weapon.PhysicalArmorBoost;
    }

    private void CalculateEquipementMagicArmorBoost()
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