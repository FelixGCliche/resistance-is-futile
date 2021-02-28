using Entity;
using UnityEngine;
using Utils.Const;

namespace Factory
{
  public class CharacterFactory : MonoBehaviour
  {
    public static Character CreateCharacterByType(CharacterType characterType)
    {
      return characterType switch
      {
        CharacterType.FLYING_EYE => 
          Instantiate(CharacterPrefabs.FLYING_EYE, CharacterPosition.Positions[0],
          Quaternion.identity),
        CharacterType.GOBLIN => 
          Instantiate(CharacterPrefabs.GOBLIN, CharacterPosition.Positions[1],
          Quaternion.identity),
        CharacterType.HUNTRESS => 
          Instantiate(CharacterPrefabs.HUNTRESS, CharacterPosition.Positions[2],
          Quaternion.identity),
        CharacterType.SKELETON => 
          Instantiate(CharacterPrefabs.SKELETON, CharacterPosition.Positions[3],
          Quaternion.identity),
        CharacterType.WARRIOR => 
          Instantiate(CharacterPrefabs.WARRIOR, CharacterPosition.Positions[4],
          Quaternion.identity),
        CharacterType.WIZARD => 
          Instantiate(CharacterPrefabs.WIZARD, CharacterPosition.Positions[5],
          Quaternion.identity),
        _ => null
      };
    }
  }
}