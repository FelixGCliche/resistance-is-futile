using Equipment;
using Stats;
using UnityEngine;
using Random = UnityEngine.Random;

public class Character : MonoBehaviour
{
  [SerializeField] private int level = 1;
  [SerializeField] public int playerId = 0;
  [SerializeField] private bool isPlayer = true;

  private CharacterEquipementManager currentEquipement;
  private CharacterStats stats;

  public CharacterStats Stats => stats;
  public bool IsDead => stats.IsDead;

  private void Awake()
  {
    stats = gameObject.AddComponent<CharacterStats>();
  }

  // Start is called before the first frame update
  void Start()
  {
    if (isPlayer)
      BattleEventManager.current.characters[playerId - 1] = this;
    BattleEventManager.current.onAttack += OnDefend;
  }

  // Update is called once per frame
  void Update()
  {
    if (BattleEventManager.current.GetCurrentAttackerId() == playerId)
    {
      if (isPlayer)
      {
        //Adapt to different player attack
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
          Debug.Log("Player " + playerId + " attacks player " + 4);
          BattleEventManager.current.OnAttack(currentEquipement.Weapon.GetAttack(4));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
          Debug.Log("Player " + playerId + " attacks player " + 5);
          BattleEventManager.current.OnAttack(currentEquipement.Weapon.GetAttack(5));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
          Debug.Log("Player " + playerId + " attacks player " + 6);
          BattleEventManager.current.OnAttack(currentEquipement.Weapon.GetAttack(6));
        }
      }
      else
      {
        //Need enemy Ai
        Debug.Log("Player " + playerId + " attacks player " + 1);
        BattleEventManager.current.OnAttack(currentEquipement.Weapon.GetAttack(Random.Range(1, 4)));
      }
    }
  }

  private void OnDefend(Attack attack, bool isCriticalHit)
  {
    if (attack.Target == playerId)
      stats.Hurt(GetTotalDamage(attack, isCriticalHit));
  }

  private int GetTotalDamage(Attack attack, bool isCriticalHit)
  {
    int totalDamage = 0;
    
    if (IsHit())
    {
      totalDamage = attack.DamageValue;
      
      if (isCriticalHit)
        totalDamage *= 2;

      if (attack.DamageType == DamageType.PHYSICAL)
        totalDamage -= stats.PhysicalArmor;

      else if (attack.DamageType == DamageType.PHYSICAL)
        totalDamage -= stats.MagicArmor;
    }

    return totalDamage;
  }

  private bool IsHit()
  {
    return Random.value <= stats.DodgeChance;
    // Mettre event rétroaction "Evade"
  }

  private bool IsCriticalHit()
  {
    return Random.value <= stats.CriticalChance;
    // Mettre event rétroaction "Critical"
  }
}