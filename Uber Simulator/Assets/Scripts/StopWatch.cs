using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StopWatch : MonoBehaviour
{
    public bool stopWatchActive = false;

    public float currentTime;

    public TimeSpan time;

    //public TextMeshProUGUI currentTimeText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        StartStopWatch();
    }

    // Update is called once per frame
    void Update()
    {
        if (stopWatchActive)
        {
            currentTime = currentTime + Time.deltaTime;
        }

         time = TimeSpan.FromSeconds(currentTime);
    
        //currentTimeText.text = time.ToString(@"mm\:ss");

    }

    public void StartStopWatch()
    {
        stopWatchActive = true;
    }

    public void StopStopWatch()
    {
        stopWatchActive = false;
    }
}