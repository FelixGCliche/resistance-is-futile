using System;
using UnityEngine;

namespace Stats
{
  public class CharacterStats : MonoBehaviour
  {
    [SerializeField] [Range(0, 100)] private int level = 0;
    [SerializeField] [Range(0, 100)] private int exp = 0;
    [SerializeField] [Range(0, 100)] private int speed = 0;
    [SerializeField] [Range(0, 100)] private int dexterity = 0;
    [SerializeField] [Range(0, 100)] private int strength = 0;
    [SerializeField] [Range(0, 100)] private int intelligence = 0;
    [SerializeField] [Range(0.0f, 1.0f)] private float dodgeChance = 0.05f;
    [SerializeField] [Range(0.0f, 1.0f)] private float critChance = 0.05f;

    public int Speed => speed;
    public int Dexterity => dexterity;
    public int Strength => strength;
    public int Intelligence => intelligence;
    public float DodgeChance => dodgeChance;
    public float CritChance => critChance;
  }
}