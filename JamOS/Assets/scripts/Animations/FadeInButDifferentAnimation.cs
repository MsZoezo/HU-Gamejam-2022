using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInButDifferentAnimation : MonoBehaviour
{
    private CanvasGroup group;

    private void Start()
    {
        group = GetComponent<CanvasGroup>();
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
