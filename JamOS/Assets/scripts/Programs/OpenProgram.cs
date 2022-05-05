using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenProgram : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] protected GameObject programPrefab;
    [SerializeField] string id;
    [SerializeField] bool onlyOne;
    [SerializeField] bool openCentered;

    private ProgramManager programManager;
    private RectTransform rt;

    #nullable enable
    protected GameObject? program;
    void Start()
    {
        programManager = FindObjectOfType<Canvas>().transform.GetComponent<ProgramManager>();
        rt = programPrefab.GetComponent<RectTransform>();
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        Vector2 position = Vector2.zero;

        if (openCentered) position = new Vector2(Screen.width / 2, Screen.height / 2);
        else position = new Vector2(Random.Range(0 + (rt.rect.width / 2), Screen.width - (rt.rect.width / 2)), Screen.height / 2);

        program = programManager.Open(programPrefab, position, id, onlyOne);
    }
}
