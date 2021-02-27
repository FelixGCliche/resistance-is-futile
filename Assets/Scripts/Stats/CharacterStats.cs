using Equipment;
using UnityEngine;
using UnityEngine.Serialization;

namespace Stats
{
  public class CharacterStats : MonoBehaviour
  {
    [SerializeField] [Range(0, 100)] private int experience = 1;
    [SerializeField] [Range(0, 100)] private int level = 1;

    [SerializeField] private int health = 1;
    [SerializeField] private int maxHealth = 10;

    [SerializeField] [Range(0, 100)] private int speed = 1;
    [SerializeField] [Range(0, 100)] private int dexterity = 1;
    [SerializeField] [Range(0, 100)] private int strength = 1;
    [SerializeField] [Range(0, 100)] private int intelligence = 1;

    [SerializeField] [Range(0, 100)] private float dodgeChance = 5;
    [SerializeField] [Range(0, 100)] private float criticalChance = 5;

    [SerializeField] [Range(0, 100)] private int physicalArmor = 0;
    [SerializeField] [Range(0, 100)] private int magicArmor = 0;

    public int Experience => experience;
    public int MaxHealth => maxHealth;
    public int Level => level;
    public int Health => health;
    public int Speed => speed;
    public int Dexterity => dexterity;
    public int Strength => strength;
    public int Intelligence => intelligence;
    public float DodgeChance => dodgeChance;
    public float CriticalChance => criticalChance;
    public int PhysicalArmor => physicalArmor;
    public int MagicArmor => magicArmor;

    public bool IsDead => health <= 0;

    public void Hurt(int damage)
    {
      health = Mathf.Clamp(health - damage, 0, maxHealth);
      Debug.Log("Health : " + health + "/" + maxHealth);
      if (health <= 0)
        BattleEventManager.current.KillTarget();
    }


  }
}