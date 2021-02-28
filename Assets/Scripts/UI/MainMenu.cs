
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("SampleScene");
        SceneManager.UnloadSceneAsync("MainMenuScene");
    }
    
    public void QuitButton()
    {
        Application.Quit();
    }
}
