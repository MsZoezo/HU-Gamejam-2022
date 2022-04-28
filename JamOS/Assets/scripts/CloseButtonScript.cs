using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class CloseButtonScript : MonoBehaviour
{
    private GameObject window;
    void Start()
    {
        window = transform.parent.parent.gameObject;
    }
    public void CloseWindow()
    {
        window.SetActive(false);
    }
}