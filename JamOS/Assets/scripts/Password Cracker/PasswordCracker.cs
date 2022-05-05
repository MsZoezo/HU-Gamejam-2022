using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class PasswordCracker : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject program;
    [SerializeField] private GameObject puzzle;
    [SerializeField] private TMP_Text selectedText;
    [SerializeField] private TMP_Text errorText;

    private string selectedItem = null;
    private ProgramManager programManager;

    private void Start()
    {
        programManager = FindObjectOfType<Canvas>().GetComponent<ProgramManager>();
    }

    public void SetSelectedItem(string item)
    {
        selectedText.text = item;
        selectedItem = item;

        if (item == null) selectedText.text = "Select...";
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(selectedItem == null)
        {
            errorText.text = "You forgot to select an item, dumbass!";
            return;
        }

        if(selectedItem != "Emtpy folder")
        {
            errorText.text = "Non protected item selected!";
            return;
        }

        if(OpenProtectedItem.canOpen == true)
        {
            errorText.text = "Item already unlocked!";
            return;
        }

        // start minigames

        programManager.Open(puzzle, new Vector2(Screen.width / 2, Screen.height / 2), "PipeGame",true);
        programManager.Close(program);
    }
}
