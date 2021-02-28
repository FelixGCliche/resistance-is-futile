using System;
using UnityEngine;

namespace Utils.Const
{
  public class CharacterPrefabs
  {
    private const string CHARACTER_PREFAB_PATH = "Prefab/Character/{0}";

    public static Character FLYING_EYE = (Character) Resources.Load(String.Format(CHARACTER_PREFAB_PATH, "FlyingEye"), typeof(Character));
    public static Character GOBLIN = (Character) Resources.Load(String.Format(CHARACTER_PREFAB_PATH, "Goblin"), typeof(Character));
    public static Character HUNTRESS = (Character) Resources.Load(String.Format(CHARACTER_PREFAB_PATH, "Huntress"), typeof(Character));
    public static Character SKELETON = (Character) Resources.Load(String.Format(CHARACTER_PREFAB_PATH, "Skeleton"), typeof(Character));
    public static Character WARRIOR = (Character) Resources.Load(String.Format(CHARACTER_PREFAB_PATH, "Warrior"), typeof(Character));
    public static Character WIZARD = (Character) Resources.Load(String.Format(CHARACTER_PREFAB_PATH, "Wizard"), typeof(Character));
  }
}