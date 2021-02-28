using Battle;
using Equipment;
using UnityEngine;
using UnityEngine.Serialization;

namespace Stats
{
  public class CharacterStats
  {
    [SerializeField] private int health = 1;
    [SerializeField] private int maxHealth = 1;

    [SerializeField] [Range(0, 100)] private int physicalArmor = 0;
    [SerializeField] [Range(0, 100)] private int magicArmor = 0;

    [SerializeField] [Range(0, 100)] private int speed = 1;

    [SerializeField] [Range(0, 100)] private int dexterity = 1;
    [SerializeField] [Range(0, 100)] private int strength = 1;
    [SerializeField] [Range(0, 100)] private int intelligence = 1;

    [SerializeField] [Range(0, 100)] private int criticalChance = 5;
    [SerializeField] [Range(0, 100)] private int dodgeChance = 5;

        public CharacterStats(int maxHealth, int physicalArmor, int magicArmor, int speed, int dexterity, int strength, int intelligence, int criticalChance, int dodgeChance)
    {
        health = maxHealth;
        this.maxHealth = maxHealth;
        this.physicalArmor = physicalArmor;
        this.magicArmor = magicArmor;
        this.speed = speed;
        this.dexterity = dexterity;
        this.strength = strength;
        this.intelligence = intelligence;
        this.criticalChance = criticalChance;
        this.dodgeChance = dodgeChance;
    }

    public int Health => health;
    public int MaxHealth => maxHealth;

    public int PhysicalArmor => physicalArmor;
    public int MagicArmor => magicArmor;

    public int Speed => speed;

    public int Dexterity => dexterity;
    public int Strength => strength;
    public int Intelligence => intelligence;

    public int CriticalChance => criticalChance;
    public int DodgeChance => dodgeChance;

    public bool IsDead => health <= 0;

    public void Hurt(int damage)
    {
      health = Mathf.Clamp(health - damage, 0, maxHealth);
      Debug.Log("Health : " + health + "/" + maxHealth);
    }
  }
}