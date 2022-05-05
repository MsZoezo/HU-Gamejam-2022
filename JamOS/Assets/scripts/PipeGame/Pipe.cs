using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Pipe : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private bool rotatable;

    [SerializeField] private bool inPath;
    [SerializeField] private int index;

    private PipeManager pipeManager = null;
    private Image background;

    public float rotation { get; private set; }

    private void Start()
    {
        background = GetComponent<Image>();

        if(rotatable) for (int i = Random.Range(1, 12); i > 0; i--) transform.Rotate(0, 0, 90);

        if (inPath)
        {
            pipeManager = transform.parent.GetComponent<PipeManager>();
            pipeManager.SetPipe(gameObject.GetComponent<Pipe>(), index);
        }

        rotation = transform.localRotation.eulerAngles.z;
    }

    public void ShowBackground()
    {
        background.color = new Color(background.color.r, background.color.g, background.color.b, 1);
    }

    public void HideBackground()
    {
        background.color = new Color(background.color.r, background.color.g, background.color.b, 0);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(rotatable) transform.Rotate(0, 0, 90);

        rotation = transform.localRotation.eulerAngles.z;

        if (pipeManager == null) return;

        pipeManager.CheckPipes();
    }
}
