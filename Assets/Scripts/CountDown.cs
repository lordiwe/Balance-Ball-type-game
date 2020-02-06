using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public Text timerText;

    public UnityEvent OnCountdownFinished;

    public float timer;

    private bool runTimer;

    private bool isPaused;

    public void StartCountdown(float duration)
    {
        timer = duration;
        runTimer = true;
    }

    public void StopCountdown()
    {
        ResetCountdown();
    }

    public void PauseCountdown()
    {
        if (!runTimer)
        {
            Debug.LogWarning("Cannot pause if not runnning");
            return;
        }

        runTimer = false;
        isPaused = true;
    }

    public void ContinueCountdown()
    {
        if (!isPaused)
        {
            Debug.LogWarning("Countdown was not paused! Cannot continue if not started");
            return;
        }

        runTimer = true;
        isPaused = false;
    }

    public void Update()
    {
        if (!runTimer) return;

        if (timer <= 0)
        {
            Finished();
        }
        
        timer -= Time.deltaTime;

        //string minutes = ((int)timer / 60).ToString();
        //string seconds = (timer % 60).ToString("f2");
        
        //timerText.text = string.Format("{0}:{1}", minutes, seconds);
    }

    public void ResetCountdown()
    {
        //timerText.text = "0:00";
        runTimer = false;
        isPaused = false;
        timer = 0;
    }

    public void Finished()
    {
        OnCountdownFinished.Invoke();

        ResetCountdown();
    }
}
