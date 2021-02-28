using System;
using System.Collections;
using Battle;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeathScreen : MonoBehaviour
{

    public static DeathScreen Current;

    private void Awake()
    {
        Current = this;
        gameObject.SetActive(false);
    }

    public void ActivateDeathScreen()
    {
        gameObject.SetActive(true);
        StartCoroutine(WaitForDeath());
    }
    
    private IEnumerator WaitForDeath()
    {
        yield return new WaitForSecondsRealtime(4);
        SceneManager.LoadScene("MainMenuScene");
        SceneManager.UnloadSceneAsync("SampleScene");
    }
}