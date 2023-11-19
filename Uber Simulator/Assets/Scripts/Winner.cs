using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Winner : MonoBehaviour
{
    public TextMeshProUGUI TextToChange;

    void Start()
    {
        TextToChange.text = Data.Name + " died!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
