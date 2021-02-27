using System.Collections;
using Equipment;
using UnityEngine;
using Random = System.Random;

namespace Stats
{
  public class CharacterStats : MonoBehaviour
  {
    [SerializeField] [Range(0, 100)] private int experience = 1;
    [SerializeField] [Range(0, 100)] private int level = 1;

    [SerializeField] [Range(0, 100)] private int vitality = 1;

    [SerializeField] [Range(0, 100)] private int speed = 1;
    [SerializeField] [Range(0, 100)] private int dexterity = 1;
    [SerializeField] [Range(0, 100)] private int strength = 1;
    [SerializeField] [Range(0, 100)] private int intelligence = 1;

    [SerializeField] [Range(0.0f, 1.0f)] private float dodgeChance = 0.05f;
    [SerializeField] [Range(0.0f, 1.0f)] private float criticalChance = 0.05f;

    [SerializeField] [Range(0, 100)] private int physicalArmor = 0;
    [SerializeField] [Range(0, 100)] private int magicArmor = 0;

    public int Experience => experience;
    public int Level => Level;
    public int Vitality => vitality;
    public int Speed => speed;
    public int Dexterity => dexterity;
    public int Strength => strength;
    public int Intelligence => intelligence;
    public float DodgeChance => dodgeChance;
    public float CriticalChance => criticalChance;
    public int PhysicalArmor => physicalArmor;
    public int MagicArmor => magicArmor;

    private Random rnd;

    private int characterId;

    public void OnAttack(Attack attack)
    {
      if (rnd.NextDouble() <= DodgeChance)
      {
        if (attack.DamageType == DamageType.PHYSICAL)
          CalculateDamage(attack.DamageValue, PhysicalArmor);
        else if (attack.DamageType == DamageType.MAGIC)
          CalculateDamage(attack.DamageValue, MagicArmor);
      }
    }

    private void CalculateDamage(int damage, int armorValue)
    {
      bool isCriticalStrike = rnd.NextDouble() <= CriticalChance;
      if (isCriticalStrike)
        damage *= 2;

      vitality -= damage - armorValue;

      if (vitality <= 0) ;
        //Remove comment and ; above once stat contains id
        //BattleEventManager.current.KillTarget(id);
    }
    
    
  }
}