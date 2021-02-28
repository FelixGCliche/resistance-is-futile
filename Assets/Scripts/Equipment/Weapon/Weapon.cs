using Battle;

namespace Equipment
{
    public class Weapon: Equipement
    {
        public Weapon(int baseDamage, DamageType damageType, WeaponType weaponType, AttackType attackType, EquipementType type, int vitalityBoost, int physicalArmorBoost, int magicArmorBoost, int speedBoost, int strengthBoost, int dexterityBoost, int intelligenceBoost, int criticalChanceBoost, int dodgeChanceBoost) : base(type, vitalityBoost, physicalArmorBoost, magicArmorBoost, speedBoost, strengthBoost, dexterityBoost, intelligenceBoost, criticalChanceBoost, dodgeChanceBoost)
        {
            BaseDamage = baseDamage;
            DamageType = damageType;
            WeaponType = weaponType;
            AttackType = attackType;
        }

        public int BaseDamage { get; }
        public DamageType DamageType { get; }
        public WeaponType WeaponType { get; }
        public AttackType AttackType { get; }

        public Attack GetAttack(int target)
        {
            return new Attack(target, BaseDamage, DamageType, WeaponType, AttackType);
        }
    }
}