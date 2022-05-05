using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerMenuAnimation : MonoBehaviour
{
    private bool shouldSlideIn = false;
    private bool shouldSlideOut = false;
    private bool isOpened = false;

    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void FixedUpdate()
    {
        if (isOpened && Input.GetMouseButton(0) && gameObject.activeSelf &&
        !RectTransformUtility.RectangleContainsScreenPoint(
        gameObject.GetComponent<RectTransform>(),
        Input.mousePosition,
        null))
        {
            Close();
        }
    }

    public void Open()
    {
        shouldSlideIn = true;
        shouldSlideOut = false;
        isOpened = true;

        StartCoroutine(SlideInAnimation());
    }

    public void Close()
    {
        shouldSlideIn = false;
        shouldSlideOut = true;
        isOpened = false;

        StartCoroutine(SlideOutAnimation());
    }


    IEnumerator SlideInAnimation()
    {
        Debug.Log(rectTransform.localPosition.y);
        while (rectTransform.anchoredPosition.y != 0)
        {
            if (!shouldSlideIn) yield break;

            rectTransform.anchoredPosition = new Vector3(rectTransform.anchoredPosition.x, Mathf.Clamp(rectTransform.anchoredPosition.y + 5, -250, 0));
            Debug.Log(rectTransform.anchoredPosition.y);

            yield return new WaitForSeconds(0.001f);
        }
    }

    IEnumerator SlideOutAnimation()
    {
        while (rectTransform.anchoredPosition.y != -250)
        {
            if (!shouldSlideOut) yield break;

            rectTransform.anchoredPosition = new Vector3(rectTransform.anchoredPosition.x, Mathf.Clamp(rectTransform.anchoredPosition.y - 5, -250, 0));
            yield return new WaitForSeconds(0.001f);
        }
    }
}
