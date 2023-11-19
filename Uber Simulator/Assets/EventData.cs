using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EventData : ScriptableObject
{
    public string EventName;
    public float GracePeriod;
    public float Cooldown;
    public float Timing;
    public bool InRoute;
    public bool InIntersection;
    
}
