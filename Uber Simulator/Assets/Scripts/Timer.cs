using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{    
    public int MinuteMargin = 5;
    public bool timerActive = false;
    public float currentTime;
    public float startMinutes;
    public TextMeshProUGUI currentTimeText;
    public float InitialSecs;

    public void Start()
    {        
        currentTime = startMinutes * 60;
        InitialSecs = currentTime * 1;
    }

    void Update()
    {
        if (timerActive)
        {
            currentTime = currentTime - Time.deltaTime;

            if (currentTime <= 0)
            {
                timerActive = false;
                Start();
                StopTimer();
            }

            if (Mathf.Round(currentTime) == 0)
            {
                currentTimeText.text = "automatic choice made";
            }


        }

        TimeSpan time = TimeSpan.FromSeconds(currentTime);

        currentTimeText.text = time.ToString(@"mm\:ss");

    }

    public void StartTimer()
    {
        timerActive = true;
    }

    public void StopTimer()
    {
        timerActive = false;
    }
}