using System.Collections;
using System.Collections.Generic;
using Equipment;
using UnityEngine;

public class Attack
{
    private int target;
    private int damageValue;
    private DamageType damageType;

    public int Target => target;

    public int DamageValue => damageValue;

    public DamageType DamageType => damageType;

    public Attack(int target, int damageValue, DamageType damageType)
    {
        this.target = target;
        this.damageValue = damageValue;
        this.damageType = damageType;
    }
}
