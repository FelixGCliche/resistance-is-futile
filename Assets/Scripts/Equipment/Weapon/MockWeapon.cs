namespace Equipment
{
  public class MockWeapon
  {
    
    private EquipementType type;
    private int level;
    private int speedBoost;
    private int strengthBoost;
    private int dexterityBoost;
    private int intelligenceBoost;
    private int dodgeChanceBoost;
    private int criticalChanceBoost;
    private int magicArmorBoost;
    private int physicalArmorBoost;
    private int vitalityBoost;
    private int baseDamage;
    private DamageType damageType;
    
    public EquipementType Type { get; }
    public int Level { get; }
    public int SpeedBoost { get; }
    public int StrengthBoost { get; }
    public int DexterityBoost { get; }
    public int IntelligenceBoost { get; }
    public int DodgeChanceBoost { get; }
    public int CriticalChanceBoost { get; }
    public int MagicArmorBoost { get; }
    public int PhysicalArmorBoost { get; }
    public int VitalityBoost { get; }
    public int BaseDamage { get; }
    public DamageType DamageType { get; }
    public Attack GetAttack(int target)
    {
      return new Attack(target, BaseDamage, DamageType);
    }
  }
}