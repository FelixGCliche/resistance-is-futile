using System.Collections.Generic;
using System.Linq;
using GameCharacter;

namespace Battle
{
  public struct BattleQueue
  {
    private Queue<Character> battleQueue;

    public BattleQueue(List<Character> characters)
    {
      battleQueue = new Queue<Character>();
      var queueOrder = characters.OrderByDescending(c => c.Stats.Speed);

      foreach (var character in characters)
      {
        battleQueue.Enqueue(character);
      }
    }

    public void EndTurn()
    {
      Character character = battleQueue.Dequeue();

      if (!character.IsDead)
        battleQueue.Enqueue(character);
    }

    private Character GetCurrentCharacter()
    {
      Character current = battleQueue.Peek();

      while (current.IsDead)
        current = battleQueue.Dequeue();

      return current;
    }
  }
}