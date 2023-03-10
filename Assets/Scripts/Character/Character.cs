using System;
using System.Collections;
using Battle;
using Equipment;
using Stats;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Character : MonoBehaviour
{
    [SerializeField] public int playerId = 0;
    [SerializeField] private CharacterStats stats;
    [SerializeField] private CharacterEquipementManager currentEquipement;
    private Animator animator;

    public CharacterStats Stats => stats;
    public CharacterEquipementManager CurrentEquipement => currentEquipement;
    public bool IsDead => stats.IsDead;

    private void Start()
    {
        BattleEventManager.Current.characters[playerId] = this;
        animator = GetComponent<Animator>();
    }

    public void SetStatsAndEquipment(CharacterStats stats, CharacterEquipementManager currentEquipement)
    {
        this.stats = stats;
        this.currentEquipement = currentEquipement;
    }

    public IEnumerator Attack()
    {
        if (playerId >= 0 && playerId < 3)
        {
            UpdateAttackPanel();
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Alpha1) ||
                                             Input.GetKeyDown(KeyCode.Alpha2) ||
                                             Input.GetKeyDown(KeyCode.Alpha3));
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
            int target = Random.Range(0, 3);
            if (BattleEventManager.Current.characters[target].IsDead)
            {
                if (target == 0)
                {
                    if (!BattleEventManager.Current.characters[1].IsDead)
                        target = 1;
                    else
                        target = 2;
                }
                else if (target == 1)
                {
                    if (!BattleEventManager.Current.characters[2].IsDead)
                        target = 2;
                    else
                        target = 0;
                }
                else
                {
                    if (!BattleEventManager.Current.characters[0].IsDead)
                        target = 0;
                    else
                        target = 1;
                }
            }

            Debug.Log("Player " + playerId + " attacks player " + target);
            BattleEventManager.Current.OnAttack(currentEquipement.Weapon.GetAttack(target));
        }

        animator.Play("Base Layer.Attack", 0, 0);
    }

    public void OnDefend(Attack attack, bool isCriticalHit)
    {
        stats.Hurt(GetTotalDamage(attack, isCriticalHit));
        if (stats.IsDead)
        {
            Debug.Log("Is dead");
            animator.Play("Base Layer.Death", 0, 0);
        }
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

        animator.Play("Base Layer.Hit", 0, 0);
        return totalDamage;
    }

    private bool IsHit()
    {
        return Random.Range(0.0f, 100.0f) > stats.DodgeChance;
        // Mettre event r??troaction "Evade"
    }

    private float GetDamageStatMultiplier(WeaponType weaponType)
    {
        switch (weaponType)
        {
            case WeaponType.INTELLIGENCE:
                return 1.0f + (float) stats.Intelligence / 100;
            case WeaponType.STRENGTH:
                return 1.0f + (float) stats.Strength / 100;
            case WeaponType.DEXTERITY:
                return 1.0f + (float) stats.Dexterity / 100;
        }

    return 1.0f;
  }

  public void ResetAnimation()
  {
      animator.Play("Base Layer.Idle", 0, 0);
  }

  private void UpdateAttackPanel()
  {
      GameObject attackPanel = GameObject.FindWithTag("AttackPanel");
      if (attackPanel != null)
      {
          attackPanel.GetComponentInChildren<TextMeshProUGUI>().text = (currentEquipement.Weapon.BaseDamage + " DMG ???");
          Image targetTop = GameObject.FindWithTag("TargetTop").GetComponent<Image>();
          Image targetMiddle = GameObject.FindWithTag("TargetMiddle").GetComponent<Image>();
          Image targetBottom = GameObject.FindWithTag("TargetBottom").GetComponent<Image>();
          if (currentEquipement.Weapon.AttackType == AttackType.SINGLE_TARGET)
          {
              targetMiddle.color = Color.white;
              targetTop.color = Color.grey;
              targetBottom.color = Color.grey;
          }
          else if (currentEquipement.Weapon.AttackType == AttackType.AOE)
          {
              targetMiddle.color = Color.white;
              targetTop.color = Color.white;
              targetBottom.color = Color.white;
          }
      }
  }
}