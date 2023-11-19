using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public string PlayerName;
    public StopWatch PlayerStopwatch;

    public bool ActivePlayer;

    public PlayerInfo(string Name)
    {
        PlayerName = Name;

        ActivePlayer = false;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
