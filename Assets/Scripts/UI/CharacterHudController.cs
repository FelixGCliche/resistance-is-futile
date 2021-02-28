using UnityEngine;

namespace UI
{
  public class CharacterHudController : MonoBehaviour
  {
    private Character character;

    public Character Character => character;

    private void Awake()
    {
      character = GetComponentInParent<Character>();
    }
  }
}