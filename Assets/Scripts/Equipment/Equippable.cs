namespace Equipment
{
    public class Equippable
    {
        public Equippable(EquipementType type, int level, int speedBoost, int strengthBoost, int dexterityBoost, int intelligenceBoost, int dodgeChanceBoost, int criticalChanceBoost, int magicArmorBoost, int physicalArmorBoost, int vitalityBoost)
        {
            Type = type;
            Level = level;
            SpeedBoost = speedBoost;
            StrengthBoost = strengthBoost;
            DexterityBoost = dexterityBoost;
            IntelligenceBoost = intelligenceBoost;
            DodgeChanceBoost = dodgeChanceBoost;
            CriticalChanceBoost = criticalChanceBoost;
            MagicArmorBoost = magicArmorBoost;
            PhysicalArmorBoost = physicalArmorBoost;
            VitalityBoost = vitalityBoost;
        }

        EquipementType Type { get; }
    
        int Level { get; }
    
        public int SpeedBoost { get; }
        public int StrengthBoost { get; }
        public int DexterityBoost { get; }
        public int IntelligenceBoost { get; }
        public int DodgeChanceBoost { get; }
        public int CriticalChanceBoost { get; }

        public int MagicArmorBoost { get; }
        public int PhysicalArmorBoost { get; }
        public int VitalityBoost { get; }
    }
}