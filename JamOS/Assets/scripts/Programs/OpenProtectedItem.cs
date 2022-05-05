using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenProtectedItem : OpenProgram
{
    public static bool canOpen;

    [SerializeField] GameObject thisFolder;
    [SerializeField] GameObject protectedFolder;

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (!canOpen) base.OnPointerClick(eventData);
        else
        {
            thisFolder.SetActive(false);
            protectedFolder.SetActive(true);
        }
    }
}
