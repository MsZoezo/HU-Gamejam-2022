using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class SelectItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject program;
    [SerializeField] private TMP_Text selectedText;

    private string selectedItem = null;

    private ProgramManager programManager;
    private PasswordCracker passwordCracker;

    private void Start()
    {
        programManager = FindObjectOfType<Canvas>().GetComponent<ProgramManager>();

        GameObject PCProgram = programManager.GetById("Password Cracker");

        if (PCProgram == null) return;

        passwordCracker = PCProgram.transform.GetComponentInChildren<PasswordCracker>();
    }

    // Als je deze functie hernoemd breek je alles. plz dont <3
    public void setSelectedItem(string item)
    {
        selectedText.text = item;
        selectedItem = item;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        passwordCracker.SetSelectedItem(selectedItem);
        programManager.Close(program);
    }
}
