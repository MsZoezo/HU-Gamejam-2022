using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInAnimation : MonoBehaviour
{
    private CanvasGroup group;
    public void Start()
    {
        group = GetComponent<CanvasGroup>();
    }

    public void StartAnimation()
    {
        StartCoroutine(Animation());
    }

    IEnumerator Animation()
    {
        while (group.alpha != 1f)
        {
            group.alpha += 0.05f;
            yield return new WaitForSeconds(0.01f);
        }

        group.interactable = true;
    }
}
