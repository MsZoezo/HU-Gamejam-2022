using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingAnimation : MonoBehaviour
{
    [SerializeField] private FadeInAnimation fadeInAnimation;
    [SerializeField] private Slider slider;
    [SerializeField] private Image image;

    private AudioSource audioData;
    private CanvasGroup group;

    void Start()
    {
        group = GetComponent<CanvasGroup>();
        audioData = GetComponent<AudioSource>();
        
        StartCoroutine(Animation());
    }

    IEnumerator Animation()
    {
        while (image.color.a != 0f)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, Mathf.Clamp(image.color.a - 0.025f, 0f, 1f));
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(0.1f);

        int percent = 0;
        float wacht = Random.Range(0.01f, 0.15f);

        for (int i = percent; percent < 25; i++)
        {
            slider.value = i;

            percent++;
            yield return new WaitForSeconds(wacht);
        }

        wacht = Random.Range(0.15f, 0.30f);

        for (int i = percent; percent < 35; i++)
        {
            slider.value = i;

            percent++;
            yield return new WaitForSeconds(wacht);
        }

        wacht = Random.Range(0.01f, 0.05f);

        for (int i = percent; percent < 70; i++)
        {
            slider.value = i;

            percent++;
            yield return new WaitForSeconds(wacht);
        }

        wacht = 0.05f;

        for (int i = percent; percent < 100; i++)
        {
            slider.value = i;

            percent++;
            yield return new WaitForSeconds(wacht);
        }

        audioData.Play();

        while(group.alpha != 0f)
        {
            group.alpha -= 0.05f;
            yield return new WaitForSeconds(0.01f);
        }


        yield return new WaitForSeconds(0.25f);

        fadeInAnimation.StartAnimation();
    }
}
