using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PipeManager : MonoBehaviour
{

    [SerializeField] private Pipe begin;
    [SerializeField] private Pipe end;

    [SerializeField] private TMP_Text title;

    [SerializeField] private GameObject virus;
    [SerializeField] private GameObject explorer;

    private Pipe[] pipes = new Pipe[11];
    private List<float>[] correctRotations = new List<float>[11] { new List<float> { 180f, 0f, -90f }, new List<float> { 270f }, new List<float> { 270f, 90f, -90f }, new List<float> { 90f }, new List<float> { 0f, 270f, -90f }, new List<float> { 90f, 270f, -90f }, new List<float> { -1f }, new List<float> { 270f, -90f }, new List<float> { 90f, 270f, -90f }, new List<float> { 90f, 270f, -90f }, new List<float> { -1f }  };

    private bool stopTimer = false;

    private float timeRemaining = 15f;

    private void Update()
    {
        if (stopTimer) return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining < 0f) timeRemaining = 0f;

        float seconds = Mathf.FloorToInt(timeRemaining % 60);
        float milliSeconds = (timeRemaining % 1) * 1000;
        title.text = "Hax - " + string.Format("({0:00}:{1:000})", seconds, milliSeconds);

        if (timeRemaining != 0f) return;

        stopTimer = true;

        CanvasGroup group = GetComponent<CanvasGroup>();
        group.interactable = false;
        group.blocksRaycasts = false;

        ProgramManager programManager = FindObjectOfType<Canvas>().GetComponent<ProgramManager>();
        RectTransform rt = virus.GetComponent<RectTransform>();

        for(int i = 0; i < 6; i++)
        {
            programManager.Open(virus, new Vector2(Screen.width / 2, Screen.height / 2), "Sucky virus", false);
        }
    }

    public void SetPipe(Pipe pipe, int index)
    {
        pipes[index] = pipe;
    }

    public void CheckPipes()
    {        
        bool valid = true;
        for (int i = 0; i < 11; i++)
        {
            if(pipes[i] == null)
            {
                valid = false;
                continue;
            }

            if(!valid)
            {
                pipes[i].HideBackground();
                continue;
            }

            List<float> correctList = correctRotations[i];

            bool localValid = false;
            foreach (float correctRotation in correctList)
            {
                if (correctRotation == -1f) localValid = true;
                if (correctRotation == pipes[i].rotation) localValid = true;
            }

            if (!localValid) valid = false;
        }

        if(valid)
        {
            stopTimer = true;

            foreach(Pipe pipe in pipes) pipe.ShowBackground();

            end.ShowBackground();

            CanvasGroup group = GetComponent<CanvasGroup>();
            group.interactable = false;
            group.blocksRaycasts = false;

            ProgramManager programManager = FindObjectOfType<Canvas>().GetComponent<ProgramManager>();
            RectTransform rt = explorer.GetComponent<RectTransform>();

            OpenProtectedItem.canOpen = true;
            GameObject program = programManager.Open(explorer, new Vector2(Screen.width / 2, Screen.height / 2), "File Explorer", false);

            if (program == null) return;

            program.transform.Find("Emtpy folder").gameObject.SetActive(true);
        }
    }
}
