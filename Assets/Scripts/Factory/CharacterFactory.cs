using Entity;
using UnityEngine;
using Utils.Const;

namespace Factory
{
  public class CharacterFactory : MonoBehaviour
  {
    public static Character CreateCharacterByType(CharacterType characterType, int id)
    {
      Character character;
      
      switch (characterType)
      {
        case CharacterType.FLYING_EYE:
          character = Instantiate(CharacterPrefabs.FLYING_EYE, CharacterPosition.Positions[id], Quaternion.identity);
          character.PlayerId = id;
          return character;
        case CharacterType.GOBLIN:
          character = Instantiate(CharacterPrefabs.GOBLIN, CharacterPosition.Positions[id], Quaternion.identity);
          character.PlayerId = id;
          return character;
        case CharacterType.HUNTRESS:
          character = Instantiate(CharacterPrefabs.HUNTRESS, CharacterPosition.Positions[id], Quaternion.identity);
          character.PlayerId = id;
          return character;
        case CharacterType.SKELETON:
          character = Instantiate(CharacterPrefabs.SKELETON, CharacterPosition.Positions[id], Quaternion.identity);
          character.PlayerId = id;
          return character;
        case CharacterType.WARRIOR:
          character = Instantiate(CharacterPrefabs.WARRIOR, CharacterPosition.Positions[id], Quaternion.identity);
          character.PlayerId = id;
          return character;
        case CharacterType.WIZARD:
          character = Instantiate(CharacterPrefabs.WIZARD, CharacterPosition.Positions[id], Quaternion.identity);
          character.PlayerId = id;
          return character;
        default:
          return null;
      }
    }
  }
}