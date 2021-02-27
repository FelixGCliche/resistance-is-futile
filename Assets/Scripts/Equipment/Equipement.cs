namespace Equipment
{
    public class Equipement
    {
        public Equipement(EquipementType type, int level, int speedBoost, int strengthBoost, int dexterityBoost, int intelligenceBoost, int dodgeChanceBoost, int criticalChanceBoost, int magicArmorBoost, int physicalArmorBoost, int maxHealthBoost)
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
            MaxHealthBoost = maxHealthBoost;
        }

        public EquipementType Type { get; }
    
        int Level { get; }
    
        public int SpeedBoost { get; }
        public int StrengthBoost { get; }
        public int DexterityBoost { get; }
        public int IntelligenceBoost { get; }
        public int DodgeChanceBoost { get; }
        public int CriticalChanceBoost { get; }

        public int MagicArmorBoost { get; }
        public int PhysicalArmorBoost { get; }
        public int MaxHealthBoost { get; }
    }
}