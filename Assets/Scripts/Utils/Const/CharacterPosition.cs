using UnityEngine;

namespace Utils.Const
{
  public struct CharacterPosition
  {
    public static Vector3[] Positions =
    {
      // Player top
      new Vector3(-5, -2.5f, 0),
      // Player middle
      new Vector3(-4, -0.5f, 0),
      // Player bottom
      new Vector3(-3, 1.5f, 0),
      // Enemy top
      new Vector3(5, -2.5f, 0),
      // Enemy middle
      new Vector3(4, -0.5f, 0),
      // Enemy bottom
      new Vector3(3, 1.5f, 0)
    };
  }
}