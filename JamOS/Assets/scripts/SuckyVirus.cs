using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuckyVirus : MonoBehaviour
{
    private RectTransform rectTransform;
    private Vector2 direction;
    private AudioSource audioSource;

    [SerializeField] Image icon;

    [SerializeField] Sprite face1;
    [SerializeField] Sprite face2;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        direction = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));

        audioSource = GetComponent<AudioSource>();

        StartCoroutine(AnnoyingAudio());
        StartCoroutine(Faces());
    }

    IEnumerator AnnoyingAudio()
    {
        while(true)
        {
            audioSource.Play();
            yield return new WaitForSeconds(Random.Range(0, 2.5f));
        }
    }

    IEnumerator Faces()
    {
        while (true)
        {
            icon.sprite = face2;
            yield return new WaitForSeconds(0.25f);
            icon.sprite = face1;
            yield return new WaitForSeconds(0.25f);
        }
    }

    void FixedUpdate()
    {
        if (rectTransform.anchoredPosition.x <= 0) direction.x *= -1;
        else if (rectTransform.anchoredPosition.x + rectTransform.rect.width >= Screen.width) direction.x *= -1;
        else if (rectTransform.anchoredPosition.y >= 0) direction.y *= -1;
        else if (rectTransform.anchoredPosition.y - rectTransform.rect.height <= Screen.height * -1) direction.y *= -1;

        rectTransform.anchoredPosition = new Vector3(rectTransform.anchoredPosition.x + direction.x, rectTransform.anchoredPosition.y + direction.y);
    }
}
