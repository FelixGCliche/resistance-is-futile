
using System;
using System.Collections;
using Battle;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private HealthBar enemy1HealthBar;
    [SerializeField] private HealthBar enemy2HealthBar;
    [SerializeField] private HealthBar enemy3HealthBar;
    
    private void Start()
    {
        StartCoroutine(WaitForEnabledEnemy());
    }

    private IEnumerator WaitForEnabledEnemy()
    {
        yield return new WaitUntil(() => BattleEventManager.Current.characters[3] != null && 
                                         BattleEventManager.Current.characters[4] != null && 
                                         BattleEventManager.Current.characters[5] != null);
        enemy1HealthBar.Character = BattleEventManager.Current.characters[3];
        enemy2HealthBar.Character = BattleEventManager.Current.characters[4];
        enemy3HealthBar.Character = BattleEventManager.Current.characters[5];
    }
}
