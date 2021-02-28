using System.Collections.Generic;
using System.Linq;

namespace Battle
{
  public struct BattleQueue
  {
    private Queue<Character> battleQueue;
    private bool isInBattle;

    public BattleQueue(IEnumerable<Character> characters)
    {
      battleQueue = new Queue<Character>();
      var queueOrder = characters.OrderByDescending(c => c.Stats.Speed);

      foreach (var character in queueOrder)
      {
        if (!character.IsDead)
          battleQueue.Enqueue(character);
      }

      isInBattle = true;
    }

    public void EndTurn()
    {
      Character character = battleQueue.Dequeue();

      if (!character.IsDead)
        battleQueue.Enqueue(character);
      
      BattleEventManager.Current.VerifyBattleEnd();
    }

    public Character GetCurrentCharacter()
    {
      if (!isInBattle)
        return null;
      
      Character current = battleQueue.Peek();

      while (current.IsDead)
        current = battleQueue.Dequeue();

      return current;
    }

    public void StopQueue()
    {
      isInBattle = false;
    }
  }
}