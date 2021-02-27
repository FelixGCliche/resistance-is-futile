using Equipment;
using UnityEngine;

namespace Stats
{
  public class CharacterStats : MonoBehaviour
  {
    [SerializeField] [Range(0, 100)] private int experience = 1;
    [SerializeField] [Range(0, 100)] private int level = 1;

    [SerializeField] [Range(0, 100)] private int vitality = 1;
    [SerializeField] private int maxVitality = 1;

    [SerializeField] [Range(0, 100)] private int speed = 1;
    [SerializeField] [Range(0, 100)] private int dexterity = 1;
    [SerializeField] [Range(0, 100)] private int strength = 1;
    [SerializeField] [Range(0, 100)] private int intelligence = 1;

    [SerializeField] [Range(0, 100)] private float dodgeChance = 5;
    [SerializeField] [Range(0, 100)] private float criticalChance = 5;

    [SerializeField] [Range(0, 100)] private int physicalArmor = 0;
    [SerializeField] [Range(0, 100)] private int magicArmor = 0;

    public int Experience => experience;
    public int Level => level;
    public int Vitality => vitality;
    public int Speed => speed;
    public int Dexterity => dexterity;
    public int Strength => strength;
    public int Intelligence => intelligence;
    public float DodgeChance => dodgeChance;
    public float CriticalChance => criticalChance;
    public int PhysicalArmor => physicalArmor;
    public int MagicArmor => magicArmor;

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