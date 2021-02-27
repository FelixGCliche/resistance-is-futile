namespace Equipment
{
    public class Equipement
    {
        public Equipement(EquipementType type, int vitalityBoost, int physicalArmorBoost, int magicArmorBoost, int speedBoost, int strengthBoost, int dexterityBoost, int intelligenceBoost, int criticalChanceBoost, int dodgeChanceBoost)
        {
            Type = type;

            VitalityBoost = vitalityBoost;

            PhysicalArmorBoost = physicalArmorBoost;
            MagicArmorBoost = magicArmorBoost;

            SpeedBoost = speedBoost;

            StrengthBoost = strengthBoost;
            DexterityBoost = dexterityBoost;
            IntelligenceBoost = intelligenceBoost;

            CriticalChanceBoost = criticalChanceBoost;
            DodgeChanceBoost = dodgeChanceBoost;
        }

        public EquipementType Type { get; }

        public int VitalityBoost { get; }

        public int PhysicalArmorBoost { get; }
        public int MagicArmorBoost { get; }

        public int SpeedBoost { get; }

        public int StrengthBoost { get; }
        public int DexterityBoost { get; }
        public int IntelligenceBoost { get; }

        public int CriticalChanceBoost { get; }
        public int DodgeChanceBoost { get; }
    }
}