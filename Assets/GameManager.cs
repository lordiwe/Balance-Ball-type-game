using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject pauseButton;
    public GameObject timer;
    public GameObject lifes;
    public void GameOver()
    {
        Time.timeScale = 0f;
        FindObjectOfType<FixedJoystick>().gameObject.SetActive(false);
        pauseButton.SetActive(false);
        timer.gameObject.SetActive(false);
        lifes.SetActive(false);
        gameOverScreen.SetActive(true);
    }
    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
