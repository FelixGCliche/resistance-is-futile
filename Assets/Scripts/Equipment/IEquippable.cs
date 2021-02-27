namespace Equipment
{
  public interface IEquippable
  {
    EquipementType Type { get; }
    
    int Level { get; }
    
    int SpeedBoost { get; }
    int StrengthBoost { get; }
    int DexterityBoost { get; }
    int IntelligenceBoost { get; }
    int DodgeChanceBoost { get; }
    int CriticalChanceBoost { get; }

    int MagicArmorBoost { get; }
    int PhysicalArmorBoost { get; }
    int VitalityBoost { get; }
  }
}