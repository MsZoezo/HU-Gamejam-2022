using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class OpenError : OpenProgram
{
    [SerializeField] private TextAsset textAsset;
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);

        if (program == null) return;

        TMP_Text errorMessage = program.transform.Find("Content").GetComponentInChildren<TMP_Text>();
        errorMessage.text = textAsset.text;

        AudioSource audioSource = program.GetComponent<AudioSource>();
        audioSource.Play();
    }
}