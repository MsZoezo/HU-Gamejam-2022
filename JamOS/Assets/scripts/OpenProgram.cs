using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenProgram : MonoBehaviour
{
    [SerializeField] GameObject programWindow;
    private RectTransform rectTransform;
    private void Start()
    {
        rectTransform = programWindow.GetComponent<RectTransform>();
    }

    public void Open()
    {
        if (programWindow.activeSelf) return;

        rectTransform.position = new Vector3(Screen.width / 2, Screen.height / 2);

        programWindow.SetActive(true);
    }
}
