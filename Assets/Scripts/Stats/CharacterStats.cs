using Equipment;
using UnityEngine;

namespace Stats
{
  public class CharacterStats : MonoBehaviour
  {
    [SerializeField] [Range(0, 100)] private int vitality = 1;
    [SerializeField] private int maxVitality = 1;

    [SerializeField] [Range(0, 100)] private int physicalArmor = 0;
    [SerializeField] [Range(0, 100)] private int magicArmor = 0;

    [SerializeField] [Range(0, 100)] private int speed = 1;

    [SerializeField] [Range(0, 100)] private int dexterity = 1;
    [SerializeField] [Range(0, 100)] private int strength = 1;
    [SerializeField] [Range(0, 100)] private int intelligence = 1;

    [SerializeField] [Range(0, 100)] private int criticalChance = 5;
    [SerializeField] [Range(0, 100)] private int dodgeChance = 5;

        public CharacterStats(int maxVitality, int physicalArmor, int magicArmor, int speed, int dexterity, int strength, int intelligence, int criticalChance, int dodgeChance)
    {
        vitality = maxVitality;
        this.maxVitality = maxVitality;
        this.physicalArmor = physicalArmor;
        this.magicArmor = magicArmor;
        this.speed = speed;
        this.dexterity = dexterity;
        this.strength = strength;
        this.intelligence = intelligence;
        this.criticalChance = criticalChance;
        this.dodgeChance = dodgeChance;
    }

    public int Vitality => vitality;

    public int PhysicalArmor => physicalArmor;
    public int MagicArmor => magicArmor;

    public int Speed => speed;

    public int Dexterity => dexterity;
    public int Strength => strength;
    public int Intelligence => intelligence;

    public int CriticalChance => criticalChance;
    public int DodgeChance => dodgeChance;

    public bool IsDead => vitality <= 0;

    public void Hurt(int damage)
    {
      vitality = Mathf.Clamp(vitality - damage, 0, maxVitality);
      Debug.Log("Health : " + vitality + "/" + maxVitality);
      if (vitality <= 0)
        BattleEventManager.current.KillTarget();
    }
  }
}