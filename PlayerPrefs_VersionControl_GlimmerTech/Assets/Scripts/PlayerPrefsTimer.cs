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
    private int lastSec;
    //private bool timerRunning;
    public TMP_Text longestText;
    public AudioClip tick;
    public AudioClip tock;

    public bool pauseTimer = true;

    private AudioSource clock;

    void Start()
    {
        startTime = Time.time;
        clock = GetComponent<AudioSource>();
        if(PlayerPrefs.GetString("LongestTime") != null)
        {
            longestText.text = PlayerPrefs.GetString("LongestTime");
        }
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

            if((int)timeDifference > lastSec)
            {
                if(lastSec % 2 == 0)
                {
                    clock.PlayOneShot(tick);
                }
                else
                {
                    clock.PlayOneShot(tock);
                }

                lastSec = (int)timeDifference;
            }
        }
        
    }

    private void OnDisable()
    {
        SaveTimer(); 
    }

    public void PauseTimer()
    {
        pauseTimer = true;
        addTime = timeDifference;
        SaveTimer();
    }

    public void StartTimer()
    {
        startTime = Time.time;
        pauseTimer = false;
    }

    public void ClearTimer() //Full clear of the timer. Reset button.
    {
        SaveTimer();
        startTime = Time.time;
        addTime = 0.0f;
        timeDifference = 0.0f;
        timerText.text = "00:00.00";
        lastSec = 0;
    }

    public void SaveTimer()
    {
        if(timeDifference > PlayerPrefs.GetFloat("FloatTime"))
        {
            PlayerPrefs.SetFloat("FloatTime", timeDifference);
            PlayerPrefs.SetString("LongestTime", timerText.text);
            longestText.text = PlayerPrefs.GetString("LongestTime");
        }
    }
    
    public void ClearSavedTimer()
    {
        PlayerPrefs.SetFloat("FloatTime", 0.0f);
        PlayerPrefs.SetString("LongestTime", "00:00.00");
        longestText.text = PlayerPrefs.GetString("LongestTime");
    }

    private void OnApplicationPause(bool pause)
    {
        SaveTimer();
    }

    private void OnApplicationQuit()
    {
        SaveTimer();
    }
}
