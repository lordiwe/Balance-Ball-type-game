using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SceneFader sceneFader;

    private string lvlSelector = "Level Selection";

    private void Start()
    {
        OptionsMenu options = new OptionsMenu();
        options.ChangeToggle();
    }

    public void PlayGame()
    {
        sceneFader.FadeTo(lvlSelector);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
