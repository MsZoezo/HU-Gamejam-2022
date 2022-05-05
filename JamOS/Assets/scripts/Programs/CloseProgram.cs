using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CloseProgram : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject program;

    private ProgramManager programManager;
    private CursorManager cursorManager;

    public void Start()
    {
        programManager = FindObjectOfType<Canvas>().GetComponent<ProgramManager>();
        cursorManager = FindObjectOfType<Canvas>().GetComponent<CursorManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        programManager.Close(program);
        cursorManager.SetCursorMode(CursorManager.CursorType.Normal);
    }
}
