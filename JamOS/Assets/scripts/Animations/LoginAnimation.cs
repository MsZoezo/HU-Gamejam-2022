using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginAnimation : MonoBehaviour
{
    [SerializeField] private Image image;

    private CanvasGroup group;
    
    void Start()
    {
        group = GetComponent<CanvasGroup>();
    }

    public void StartAnimation()
    {
        group.interactable = false;
        StartCoroutine(Animation());
    }

    IEnumerator Animation()
    {
        while(group.alpha != 0f || image.color.a != 0f)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, Mathf.Clamp(image.color.a - 0.05f, 0f, 1f));
            group.alpha = Mathf.Clamp(group.alpha - 0.05f, 0f, 1f);

            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(0.25f);

        SceneManager.LoadScene("OS");
    }
}
