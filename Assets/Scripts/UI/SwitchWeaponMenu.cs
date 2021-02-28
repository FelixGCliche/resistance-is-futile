
using System;
using Battle;
using Equipment;
using UI;
using UnityEngine;

public class SwitchWeaponMenu : MonoBehaviour
{
    [SerializeField] private WeaponCard newWeaponCard;
    [SerializeField] private WeaponCard weaponCardPlayer1;
    [SerializeField] private WeaponCard weaponCardPlayer2;
    [SerializeField] private WeaponCard weaponCardPlayer3;
    
    public static SwitchWeaponMenu current;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void ActivateSwitchWeaponMenu()
    {
        gameObject.SetActive(true);
    }

    public void GetNewCards(Equipement newEquipement)
    {
        if (newEquipement.Type == EquipementType.WEAPON)
        {
            newWeaponCard.NewWeapon = (Weapon)newEquipement;
            weaponCardPlayer1.NewWeapon = BattleEventManager.Current.characters[0].CurrentEquipement.Weapon;
            weaponCardPlayer2.NewWeapon = BattleEventManager.Current.characters[1].CurrentEquipement.Weapon;
            weaponCardPlayer3.NewWeapon = BattleEventManager.Current.characters[2].CurrentEquipement.Weapon;
        }
        else
        {
            newWeaponCard.NewEquipement = newEquipement;
            if (newEquipement.Type == EquipementType.HELMET)
            {
                weaponCardPlayer1.NewEquipement = BattleEventManager.Current.characters[0].CurrentEquipement.Helmet;
                weaponCardPlayer2.NewEquipement = BattleEventManager.Current.characters[1].CurrentEquipement.Helmet;
                weaponCardPlayer3.NewEquipement = BattleEventManager.Current.characters[2].CurrentEquipement.Helmet;
            }
            else
            if (newEquipement.Type == EquipementType.CHESTPIECE)
            {
                weaponCardPlayer1.NewEquipement = BattleEventManager.Current.characters[0].CurrentEquipement.ChestPiece;
                weaponCardPlayer2.NewEquipement = BattleEventManager.Current.characters[1].CurrentEquipement.ChestPiece;
                weaponCardPlayer3.NewEquipement = BattleEventManager.Current.characters[2].CurrentEquipement.ChestPiece;
            }
            else
            if (newEquipement.Type == EquipementType.GREAVES)
            {
                weaponCardPlayer1.NewEquipement = BattleEventManager.Current.characters[0].CurrentEquipement.Greaves;
                weaponCardPlayer2.NewEquipement = BattleEventManager.Current.characters[1].CurrentEquipement.Greaves;
                weaponCardPlayer3.NewEquipement = BattleEventManager.Current.characters[2].CurrentEquipement.Greaves;
            }
            else
            if (newEquipement.Type == EquipementType.BOOTS)
            {
                weaponCardPlayer1.NewEquipement = BattleEventManager.Current.characters[0].CurrentEquipement.Boots;
                weaponCardPlayer2.NewEquipement = BattleEventManager.Current.characters[1].CurrentEquipement.Boots;
                weaponCardPlayer3.NewEquipement = BattleEventManager.Current.characters[2].CurrentEquipement.Boots;
            }
            else
            if (newEquipement.Type == EquipementType.NECKLACE)
            {
                weaponCardPlayer1.NewEquipement = BattleEventManager.Current.characters[0].CurrentEquipement.Necklace;
                weaponCardPlayer2.NewEquipement = BattleEventManager.Current.characters[1].CurrentEquipement.Necklace;
                weaponCardPlayer3.NewEquipement = BattleEventManager.Current.characters[2].CurrentEquipement.Necklace;
            }
            else
            if (newEquipement.Type == EquipementType.RING)
            {
                weaponCardPlayer1.NewEquipement = BattleEventManager.Current.characters[0].CurrentEquipement.Ring;
                weaponCardPlayer2.NewEquipement = BattleEventManager.Current.characters[1].CurrentEquipement.Ring;
                weaponCardPlayer3.NewEquipement = BattleEventManager.Current.characters[2].CurrentEquipement.Ring;
            }
        }
            
        
    }
    
}
