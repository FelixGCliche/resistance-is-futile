using System;
using DG.Tweening;
using Factory;
using UnityEngine;

namespace Battle
{
  public class Test : MonoBehaviour
  {
    private void Awake()
    {
      for (int i = 0; i < 6; i++)
      {
        Character character = CharacterFactory.CreateCharacterByType((CharacterType) i, i);
        if (i >= 3)
          character.transform.DOScaleX(-1.0f, 0);
      }
    }
  }
}