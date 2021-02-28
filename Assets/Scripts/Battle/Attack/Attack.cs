using Equipment;
using UnityEngine;

namespace Battle
{
    public struct Attack
    {
        private int target;
        private int damageValue;
        private DamageType damageType;
        private WeaponType weaponType;
        private AttackType attackType;

        public int Target => target;

        public int DamageValue => damageValue;

        public DamageType DamageType => damageType;

        public WeaponType WeaponType => weaponType;

        public AttackType AttackType => attackType;

        public void SetTarget(int target)
        {
            this.target = target;
        }

        public Attack(int target, int damageValue, DamageType damageType, WeaponType weaponType, AttackType attackType)
        {
            this.target = target;
            this.damageValue = damageValue;
            this.damageType = damageType;
            this.weaponType = weaponType;
            this.attackType = attackType;
        }
    }
}
