using Battle;
using Equipment;
using Factory;
using Stats;
using UnityEngine;
using Random = UnityEngine.Random;

public class Character : MonoBehaviour
{
  [SerializeField] private int level = 1;
  [SerializeField] public int playerId = 0;
  [SerializeField] private bool isPlayer = true;
  [SerializeField] private CharacterStats stats;
  [SerializeField] private CharacterEquipementManager currentEquipement;

  public CharacterStats Stats => stats;
  public CharacterEquipementManager CurrentEquipement => currentEquipement;
  public bool IsDead => stats.IsDead;

  public Character(CharacterStats stats, CharacterEquipementManager currentEquipement)
  {
    this.stats = stats;
    this.currentEquipement = currentEquipement;
  }

  private void Awake()
  {
    currentEquipement.SwapEquipementWithoutStatUpdate(WeaponFactory.CreateNewWeapon(1));
    currentEquipement.SwapEquipementWithoutStatUpdate(EquipementFactory.CreateNewEquipement(1, EquipementType.RING));
    currentEquipement.SwapEquipementWithoutStatUpdate(EquipementFactory.CreateNewEquipement(1, EquipementType.BOOTS));
    currentEquipement.SwapEquipementWithoutStatUpdate(EquipementFactory.CreateNewEquipement(1, EquipementType.HELMET));
    currentEquipement.SwapEquipementWithoutStatUpdate(EquipementFactory.CreateNewEquipement(1, EquipementType.GREAVES));
    currentEquipement.SwapEquipementWithoutStatUpdate(EquipementFactory.CreateNewEquipement(1, EquipementType.NECKLACE));
    currentEquipement.SwapEquipement(EquipementFactory.CreateNewEquipement(1, EquipementType.CHESTPIECE));
  }

  // Start is called before the first frame update
  void Start()
  {
    if (isPlayer)
      BattleEventManager.Current.characters[playerId] = this;
    BattleEventManager.Current.onAttack += OnDefend;
  }

  // Update is called once per frame
  void Update()
  {
    if (BattleEventManager.Current.currentCharacter == this)
    {
      if (isPlayer)
      {
        //Adapt to different player attack
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
          Debug.Log("Player " + playerId + " attacks player " + 3);
          BattleEventManager.Current.OnAttack(currentEquipement.Weapon.GetAttack(3));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
          Debug.Log("Player " + playerId + " attacks player " + 4);
          BattleEventManager.Current.OnAttack(currentEquipement.Weapon.GetAttack(4));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
          Debug.Log("Player " + playerId + " attacks player " + 5);
          BattleEventManager.Current.OnAttack(currentEquipement.Weapon.GetAttack(5));
        }
      }
      else
      {
        //Need enemy Ai
        int target = Random.Range(0, 3);
        Debug.Log("Player " + playerId + " attacks player " + target);
        BattleEventManager.Current.OnAttack(currentEquipement.Weapon.GetAttack(target));
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
      else if (attack.DamageType == DamageType.MAGIC)
        totalDamage -= stats.MagicArmor;
    }

    return totalDamage;
  }

  private bool IsHit()
  {
    return Random.Range(0.0f, 100.0f) <= stats.DodgeChance;
    // Mettre event rétroaction "Evade"
  }
}