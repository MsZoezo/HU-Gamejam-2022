using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PasswordInput : MonoBehaviour
{
    [SerializeField] private string password;
    [SerializeField] private TMP_InputField passwordInput;

    [SerializeField] private GameObject program;
    private ProgramManager programManager;

    private int index = 0;
    private string[] errorMessages = new string[] { "Wrong password, please try again.", "Wrong password, please try again.", "Wrong password, please try again.", "Wrong password, please don't try again.", "Wrong password, please just try something else.", "Wrong password, please for the love of god just stop.", "Wrong password, please just use the damn password cracker."};

    [SerializeField] private TextMeshProUGUI errorText;

    private void Start()
    {
        programManager = FindObjectOfType<Canvas>().GetComponent<ProgramManager>();
    }

    public void Submit()
    {

        if(passwordInput.text == password)
        {
            OpenProtectedItem.canOpen = true;
            errorText.text = "";
            programManager.Close(program);
            return;
        }

        index++;

        string message = errorMessages[Mathf.Clamp(index - 1, 0, errorMessages.Length - 1)];
        message += " (" + index + ")";

        errorText.text = message;

    }
}