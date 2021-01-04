using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void RulesScene()
    {
        SceneManager.LoadScene(5);
    }

    public void ControlScene()
    {
        SceneManager.LoadScene(4);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
