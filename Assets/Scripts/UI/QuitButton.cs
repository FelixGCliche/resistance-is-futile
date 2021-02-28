using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class QuitButton : MonoBehaviour
    {
        public void OnQuitButton()
        {
            SceneManager.LoadScene("MainMenuScene");
            SceneManager.UnloadSceneAsync("SampleScene");
        }
    }
}