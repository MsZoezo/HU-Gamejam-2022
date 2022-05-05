using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private CursorManager cursorManager;

    private void Start()
    {
        cursorManager = FindObjectOfType<Canvas>().transform.GetComponent<CursorManager>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        cursorManager.SetCursorMode(CursorManager.CursorType.Hover);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        cursorManager.SetCursorMode(CursorManager.CursorType.Normal);
    }
}
