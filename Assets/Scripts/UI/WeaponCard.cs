using System;
using Equipment;
using TMPro;
using UnityEngine;

namespace UI
{
    public class WeaponCard : MonoBehaviour
    {
        private const string baseDamageText = "Base damage: ";
        private const string damageTypeText = "Damage type: ";
        private const string attackTypeText = "Attack type: ";
        private const string weaponTypeText = "Weapon type: ";
        private const string maxHealthText = "Max health: ";
        private const string magicArmorText = "Magic armor: ";
        private const string physicalArmorText = "Physical armor: ";
        private const string speedText = "Speed: ";
        private const string strengthText = "Strength: ";
        private const string dexterityText = "Dexterity: ";
        private const string intelligenceText = "Intelligence: ";
        private const string criticalChanceText = "Critical chance: ";
        private const string dodgeChanceText = "Dodge chance: ";
        
        [SerializeField] private TextMeshProUGUI equipmentName;
        [SerializeField] private TextMeshProUGUI baseDamage;
        [SerializeField] private TextMeshProUGUI damageType;
        [SerializeField] private TextMeshProUGUI attackType;
        [SerializeField] private TextMeshProUGUI weaponType;
        [SerializeField] private TextMeshProUGUI maxHealth;
        [SerializeField] private TextMeshProUGUI magicArmor;
        [SerializeField] private TextMeshProUGUI physicalArmor;
        [SerializeField] private TextMeshProUGUI speed;
        [SerializeField] private TextMeshProUGUI strength;
        [SerializeField] private TextMeshProUGUI dexterity;
        [SerializeField] private TextMeshProUGUI intelligence;
        [SerializeField] private TextMeshProUGUI criticalChance;
        [SerializeField] private TextMeshProUGUI dodgeChance;
        
        private Equipement newEquipement;
        private Weapon newWeapon;

        public Equipement NewEquipement
        {
            set
            {
                newEquipement = value;
                setNewEquipmentValues();
                equipmentName.text = newEquipement.Type.ToString();
            } 
        }
        
        public Weapon NewWeapon
        {
            set
            {
                newWeapon = value;
                setNewWeaponValues();
                equipmentName.text = "Weapon";
            } 
        }

        public void setNewWeaponValues()
        {
            baseDamage.text = baseDamageText + newWeapon.BaseDamage;
            damageType.text = damageTypeText + newWeapon.DamageType;
            attackType.text = attackTypeText + newWeapon.AttackType;
            weaponType.text = weaponTypeText + newWeapon.WeaponType;
            maxHealth.text = maxHealthText + newWeapon.VitalityBoost;
            magicArmor.text = magicArmorText + newWeapon.MagicArmorBoost;
            physicalArmor.text = physicalArmorText + newWeapon.PhysicalArmorBoost;
            speed.text = speedText + newWeapon.SpeedBoost;
            strength.text = strengthText + newWeapon.StrengthBoost;
            dexterity.text = dexterityText + newWeapon.DexterityBoost;
            intelligence.text = intelligenceText + newWeapon.IntelligenceBoost;
            criticalChance.text = criticalChanceText + newWeapon.CriticalChanceBoost;
            dodgeChance.text = dodgeChanceText + newWeapon.DodgeChanceBoost;
        }
        
        public void setNewEquipmentValues()
        {
            baseDamage.text = baseDamageText + 0;
            damageType.text = damageTypeText + "None";
            attackType.text = attackTypeText + "None";
            weaponType.text = weaponTypeText + "None";
            maxHealth.text = maxHealthText + newEquipement.VitalityBoost;
            magicArmor.text = magicArmorText + newEquipement.MagicArmorBoost;
            physicalArmor.text = physicalArmorText + newEquipement.PhysicalArmorBoost;
            speed.text = speedText + newEquipement.SpeedBoost;
            strength.text = strengthText + newEquipement.StrengthBoost;
            dexterity.text = dexterityText + newEquipement.DexterityBoost;
            intelligence.text = intelligenceText + newEquipement.IntelligenceBoost;
            criticalChance.text = criticalChanceText + newEquipement.CriticalChanceBoost;
            dodgeChance.text = dodgeChanceText + newEquipement.DodgeChanceBoost;
        }
    }
}