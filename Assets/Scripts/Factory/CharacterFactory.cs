using UnityEngine;
using Utils.Const;

namespace Factory
{
  public class CharacterFactory: MonoBehaviour
  {
    public static Character CreateCharacterByType(CharacterType characterType, int id)
    {
      switch (characterType)
      {
        case CharacterType.FLYING_EYE:
          return Instantiate(CharacterPrefabs.FLYING_EYE, CharacterPosition.Positions[id], Quaternion.identity);
        case CharacterType.GOBLIN:
          return Instantiate(CharacterPrefabs.GOBLIN, CharacterPosition.Positions[id], Quaternion.identity);
        case CharacterType.HUNTRESS:
          return Instantiate(CharacterPrefabs.HUNTRESS, CharacterPosition.Positions[id], Quaternion.identity);
        case CharacterType.SKELETON:
          return Instantiate(CharacterPrefabs.SKELETON, CharacterPosition.Positions[id], Quaternion.identity);
        case CharacterType.WARRIOR:
          return Instantiate(CharacterPrefabs.WARRIOR, CharacterPosition.Positions[id], Quaternion.identity);
        case CharacterType.WIZARD:
          return Instantiate(CharacterPrefabs.WIZARD, CharacterPosition.Positions[id], Quaternion.identity);
        default:
          return null;
      }
    }
  }
}