using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

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

    public GameObject inputWindow;

    public GameObject Blocker;

    public Text inputTitleText;

    public TMP_InputField inputField;

    public string nextlvl;

    public int nextlvlIndex;

    private readonly string mainMenuScene = "Main Menu";

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

        inputTitleText.text = "Your time: " + ConvertTime(time).ToString();
        
        PlayerPrefs.SetInt("levelReached", nextlvlIndex);

        highscoreTable.SetActive(true);

        Blocker.SetActive(true);

        inputWindow.gameObject.SetActive(true);
    }

    public void AcceptResult()
    {
        string name = inputField.text;
        float time = controller.time;
        
        highscoreTable.GetComponent<LeaderBoard>().AddHighscoreEntry(time, name);

        highscoreTable.gameObject.SetActive(false);

        Blocker.SetActive(false);

        inputWindow.gameObject.SetActive(false);

        highscoreTable.gameObject.SetActive(true);

    }

    public void ToNextLvl()
    {
        Time.timeScale = 1f;
        sceneFader.FadeTo(nextlvl);
    }

    private string ConvertTime(float time)
    {
        string minutes = ((int)time / 60).ToString();
        string seconds = (time % 60).ToString("f2");
        string timerText = minutes + ":" + seconds;
        return timerText;
    }
}
