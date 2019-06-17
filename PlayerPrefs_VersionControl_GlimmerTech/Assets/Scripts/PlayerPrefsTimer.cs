using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;

public class PlayerPrefsTimer : MonoBehaviour
{
    public TMP_Text timerText;
    private float startTime;
    private float timeDifference;
    private float addTime;
    //private bool timerRunning;

    public bool pauseTimer = true;

    void Start()
    {
        startTime = Time.time;
    }


    void Update()
    {
        float t = Time.time - startTime;
        if (pauseTimer == false)
        {
            timeDifference = Math.Abs(addTime) + t;
            string minutes;
            string seconds;

            if ((timeDifference / 60) < 10)
            {
                minutes = "0" + ((int)timeDifference / 60).ToString();

            }
            else
            {
                minutes = ((int)timeDifference / 60).ToString();
            }

            if ((timeDifference % 60) < 10)
            {
                seconds = "0" + (timeDifference % 60).ToString("f2");

            }
            else
            {
                seconds = (timeDifference % 60).ToString("f2");
            }

            timerText.text = minutes + ":" + seconds;
        }
        
    }

    public void PauseTimer()
    {
        pauseTimer = true;
        addTime = timeDifference;
    }

    public void StartTimer()
    {
        startTime = Time.time;
        pauseTimer = false;
    }

    public void ClearTimer() //Full clear of the timer. Reset button.
    {
        startTime = Time.time;
        addTime = 0.0f;
        timeDifference = 0.0f;
        timerText.text = "00:00.00";
    }

    public void SaveTimer()
    {

    }
}
