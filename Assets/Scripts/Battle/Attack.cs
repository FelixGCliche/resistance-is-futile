using Equipment;

namespace Battle
{
    public struct Attack
    {
        private int target;
        private int damageValue;
        private DamageType damageType;
        private WeaponType weaponType;

        public int Target => target;

        public int DamageValue => damageValue;

        public DamageType DamageType => damageType;

        public WeaponType WeaponType => weaponType;

        public Attack(int target, int damageValue, DamageType damageType, WeaponType weaponType)
        {
            this.target = target;
            this.damageValue = damageValue;
            this.damageType = damageType;
            this.weaponType = weaponType;
        }
    }
}
