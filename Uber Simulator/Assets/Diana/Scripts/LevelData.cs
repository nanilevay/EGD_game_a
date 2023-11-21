using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelData : ScriptableObject
{
    // insert map here

    public ClientData[] Clients;
    public EventData[] Events;
    public float TotalTime;

}
