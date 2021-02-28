using Entity;
using UnityEngine;

namespace UI
{
  public class CharacterHudController : MonoBehaviour
  {
    private Character character;
    private Canvas canvas;

    public Character Character => character;

    private void Awake()
    {
      character = GetComponentInParent<Character>();
      canvas = GetComponent<Canvas>();

      canvas.transform.position += new Vector3(0, Character.SpriteRenderer.size.y/4, 0);
    }
  }
}