using System.Collections;
using System;
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
    [SerializeField] private CharacterStats stats;
    [SerializeField] private CharacterEquipementManager currentEquipement;

    public CharacterStats Stats => stats;
    public CharacterEquipementManager CurrentEquipement => currentEquipement;
    public bool IsDead => stats.IsDead;

    public void SetStatsAndEquipment(CharacterStats stats, CharacterEquipementManager currentEquipement)
    {
        this.stats = stats;
        this.currentEquipement = currentEquipement;
    }

    public IEnumerator Attack()
    {
        if (playerId >= 0 && playerId < 3)
        {
            while (true)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    Debug.Log("Player " + playerId + " attacks player " + 3);
                    BattleEventManager.Current.OnAttack(currentEquipement.Weapon.GetAttack(3));
                    break;
                }

                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    Debug.Log("Player " + playerId + " attacks player " + 4);
                    BattleEventManager.Current.OnAttack(currentEquipement.Weapon.GetAttack(4));
                    break;
                }

                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    Debug.Log("Player " + playerId + " attacks player " + 5);
                    BattleEventManager.Current.OnAttack(currentEquipement.Weapon.GetAttack(5));
                    break;
                }

                yield return new WaitForSeconds(0.01f);
            }
        }
        else
        {
            int target = Random.Range(0, 3);
            Debug.Log("Player " + playerId + " attacks player " + target);
            BattleEventManager.Current.OnAttack(currentEquipement.Weapon.GetAttack(target));
        }
    }

    public void OnDefend(Attack attack, bool isCriticalHit)
    {
        if (attack.Target == playerId)
            stats.Hurt(GetTotalDamage(attack, isCriticalHit));
    }

    private int GetTotalDamage(Attack attack, bool isCriticalHit)
    {
        int totalDamage = 0;

    if (IsHit())
    {
      totalDamage = Mathf.CeilToInt(attack.DamageValue * GetDamageStatMultiplier(attack.WeaponType));

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

  private float GetDamageStatMultiplier(WeaponType weaponType)
  {
    switch (weaponType)
    {
      case WeaponType.INTELLIGENCE:
        return 1.0f + (float)stats.Intelligence / 100;
      case WeaponType.STRENGTH:
        return 1.0f+ (float)stats.Strength / 100;
      case WeaponType.DEXTERITY:
        return 1.0f+ (float)stats.Dexterity / 100;
    }

    return 1.0f;
  }
}