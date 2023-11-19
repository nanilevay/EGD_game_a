using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ClientData : ScriptableObject
{
    public string Name;
    public float DeliveryTime;
    public MessageData[] Messages;
    public int[] timings;   
}
