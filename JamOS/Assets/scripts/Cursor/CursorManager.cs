using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D normalCursor;
    [SerializeField] private Vector2 normalCursorHotspot;

    [SerializeField] private Texture2D hoverCursor;
    [SerializeField] private Vector2 hoverCursorHotspot;

    public enum CursorType
    {
        Normal,
        Hover
    }

    private void Start()
    {
        SetCursorMode(CursorType.Normal);
    }

    public void SetCursorMode(CursorType mode)
    {
        switch (mode)
        {
            case CursorType.Normal:
                Cursor.SetCursor(normalCursor, normalCursorHotspot, CursorMode.Auto);
                break;

            case CursorType.Hover:
                Cursor.SetCursor(hoverCursor, hoverCursorHotspot, CursorMode.Auto);
                break;

            default:
                break;
        }
    }
}
