using System;
using UnityEngine;
using TMPro;

public class PlayerTimer : MonoBehaviour
{
    public StopWatch StopWatch;
    public bool timerActive = false;
    public float currentTime;
    public float startMinutes;

    public bool once = true;

    public TimeSpan time;


    public void StartTimer()
    {
        timerActive = true;
        StopWatch.stopWatchActive = false;
        startMinutes = StopWatch.currentTime;
        currentTime = startMinutes; // * 60;
    }

    void Update()
    {
        if (timerActive)
        {
            if (once)
            {
                StartTimer();
                once = false;
            }
            currentTime = currentTime - Time.deltaTime;

            //if (currentTime <= 0)
            //{
            //    timerActive = false;
            //    StartTimer();
            //    StopTimer();
            //}

            if (Mathf.Round(currentTime) == 0)
            {
                StopTimer();
                StopWatch.currentTime = 0;
                StopWatch.stopWatchActive = true;
                once = true;
            }


        }

         time = TimeSpan.FromSeconds(currentTime);

       // currentTimeText.text = time.ToString(@"mm\:ss");


    }

    public void StopTimer()
    {
        timerActive = false;
    }
}