using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class OpenNotes : OpenProgram
{
    [SerializeField] private TextAsset textAsset;
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);

        if (program == null) return;

        TMP_InputField field = program.GetComponentInChildren<TMP_InputField>();
        field.text = textAsset.text;
    }
}
