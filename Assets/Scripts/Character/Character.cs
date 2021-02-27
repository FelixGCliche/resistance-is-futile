using Equipment;
using Stats;
using UnityEngine;

public class Character : MonoBehaviour
{
  [SerializeField] private int level = 1;
  [SerializeField] public int playerId = 1;
  [SerializeField] private bool isPlayer = true;

  private CharacterEquipementManager currentEquipement;
  private CharacterStats stats;
  private bool isDead = false;
  public bool IsDead => isDead;

  public CharacterStats Stats => stats;

  // Start is called before the first frame update
  void Start()
  {
    if (isPlayer)
      BattleEventManager.current.characters[playerId - 1] = this;
    BattleEventManager.current.onAttack += OnAttack;
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
          OnAttack(currentEquipement.Weapon.GetAttack(4));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
          Debug.Log("Player " + playerId + " attacks player " + 5);
          OnAttack(currentEquipement.Weapon.GetAttack(5));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
          Debug.Log("Player " + playerId + " attacks player " + 6);
          OnAttack(currentEquipement.Weapon.GetAttack(6));
        }
      }
      else
      {
        //Need enemy Ai
        Debug.Log("Player " + playerId + " attacks player " + 1);
        OnAttack(currentEquipement.Weapon.GetAttack(Random.Range(1, 3)));
      }
    }
  }

  private void OnAttack(Attack attack)
  {
    if (attack.Target == playerId)
      stats.OnAttack(attack);
  }

  public void Die()
  {
    isDead = true;
  }
}