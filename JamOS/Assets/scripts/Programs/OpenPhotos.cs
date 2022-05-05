using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OpenPhotos : OpenProgram
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private Vector2 size;
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);

        if (program == null) return;

        RectTransform rt = program.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(size.x + 20, size.y + 70);

        Image image = program.transform.GetChild(1).GetComponent<Image>();
        image.sprite = sprite;
    }
}