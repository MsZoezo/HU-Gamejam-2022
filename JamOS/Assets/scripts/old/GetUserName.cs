using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetUserName : MonoBehaviour
{
    private TextMeshProUGUI textMesh;

    private void Start()
    {
        textMesh = transform.GetComponent<TextMeshProUGUI>();
        textMesh.text = Environment.UserName;
    }
}
