using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DualClosePrograms : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject program;
    [SerializeField] private string programId;

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
        programManager.CloseById(programId);
        cursorManager.SetCursorMode(CursorManager.CursorType.Normal);
    }
}
