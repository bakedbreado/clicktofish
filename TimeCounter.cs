using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn = false;
    public TextMeshProUGUI timerText;
    public float TimeTaken;

    void Start()
    {
        TimerOn = false;
    }

    void Update()
    {
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                UpdateTimer(TimeLeft);
            }
            else
            {
                TimeLeft = 0;
                TimerOn = false;

                SceneManager.LoadScene(0);

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }

    void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = TimeTaken.ToString(string.Format("{1:00}", minutes, seconds));
    }

    // Add this method to start the timer
    public void StartTimer()
    {
        TimerOn = true;
    }
}

    /*public void StopTimer()
    { 
        TimerOn = false;
        if (TimeTaken < sceneBestTime)
        {
            highScore.text = TimeTaken.ToString();

            PlayerPrefs.SetFloat("CurrentBestTime", TimeTaken);
            PlayerPrefs.SetFloat("HighScore", TimeTaken);
        }

    }
}*/
