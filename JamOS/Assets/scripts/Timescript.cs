using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class Timescript : MonoBehaviour
{
    private TextMeshProUGUI currentTime;


    private void Start()
    {
        currentTime = transform.GetComponent<TextMeshProUGUI>();    
    }

    private void Update()
    {
        currentTime.text = DateTime.Now.ToShortTimeString();
    }

}
