using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SceneFader sceneFader;

    private string lvlSelector = "Level Selection";

    public void PlayGame()
    {
        sceneFader.FadeTo(lvlSelector);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
