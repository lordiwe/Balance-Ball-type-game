﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;

    public GameObject pauseButton;

    public GameObject timer;

    public GameObject lifes;

    public SceneFader sceneFader;

    public PauseMenu pauseMenu;

    public GameObject highscoreTable;

    public PlayerController controller;

    public string nextlvl;

    public int nextlvlIndex;

    private string mainMenuScene = "Main Menu";

    public void GameOver()
    {
        Time.timeScale = 0f;
        FindObjectOfType<FixedJoystick>().gameObject.SetActive(false);
        FindObjectOfType<JumpButton>().gameObject.SetActive(false);
        pauseButton.SetActive(false);
        timer.gameObject.SetActive(false);
        lifes.SetActive(false);
        gameOverScreen.SetActive(true);
    }
    public void ToMenu()
    {
        pauseMenu.Resume();
        sceneFader.FadeTo(mainMenuScene);
    }
    public void Restart()
    {
        pauseMenu.Resume();
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Finish()
    {
        Time.timeScale = 0f;
        FindObjectOfType<FixedJoystick>().gameObject.SetActive(false);
        FindObjectOfType<JumpButton>().gameObject.SetActive(false);
        pauseButton.SetActive(false);
        timer.gameObject.SetActive(false);
        lifes.SetActive(false);

        float time = controller.time;

        highscoreTable.GetComponent<LeaderBoard>().AddHighscoreEntry(time, "max");
        
        PlayerPrefs.SetInt("levelReached", nextlvlIndex);

        highscoreTable.SetActive(true);
    }
    public void ToNextLvl()
    {
        Time.timeScale = 1f;
        sceneFader.FadeTo(nextlvl);
    }
}
