using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideAnimation : MonoBehaviour
{
    private RectTransform rectTransform;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        StartCoroutine(Animation());
    }

    IEnumerator Animation()
    {
        while (rectTransform.position.y != 0)
        {
            rectTransform.position = new Vector3(rectTransform.position.x, rectTransform.position.y + 1);
            yield return new WaitForSeconds(0.005f);
        }
    }

}
