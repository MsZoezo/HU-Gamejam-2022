using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenFileExplorer : OpenProgram
{
    [SerializeField] private string folder;
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);

        if (program == null) return;

        program.transform.Find(folder).gameObject.SetActive(true);
    }
}
