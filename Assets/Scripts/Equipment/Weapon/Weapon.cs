namespace Equipment
{
    public class Weapon: Equipement
    {
        public Weapon(int baseDamage, DamageType damageType, WeaponType weaponType, EquipementType type, int level, int speedBoost, int strengthBoost, int dexterityBoost, int intelligenceBoost, int dodgeChanceBoost, int criticalChanceBoost, int magicArmorBoost, int physicalArmorBoost, int vitalityBoost) : base(type, level, speedBoost, strengthBoost, dexterityBoost, intelligenceBoost, dodgeChanceBoost, criticalChanceBoost, magicArmorBoost, physicalArmorBoost, vitalityBoost)
        {
            BaseDamage = baseDamage;
            DamageType = damageType;
            WeaponType = weaponType;
        }

        public int BaseDamage { get; }
        public DamageType DamageType { get; }
        public WeaponType WeaponType { get; }

        public Attack GetAttack(int target)
        {
            return new Attack(target, BaseDamage, DamageType);
        }
    }
}