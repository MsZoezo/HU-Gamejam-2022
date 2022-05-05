using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerUI : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;

    [SerializeField] private Sprite pauseIcon;
    [SerializeField] private Sprite resumeIcon;

    private CanvasGroup group;

    private Button pauseButton;
    private Slider slider;

    void Start()
    {
        group = GetComponent<CanvasGroup>();
        pauseButton = GetComponentInChildren<Button>();
        slider = GetComponentInChildren<Slider>();

        pauseButton.image.sprite = pauseIcon;
    }

    public void togglePlaying()
    {
        if(videoPlayer.isPlaying)
        {
            pauseButton.image.sprite = resumeIcon;
            videoPlayer.Pause();
        } else
        {
            pauseButton.image.sprite = pauseIcon;
            if(videoPlayer.frame == (long) videoPlayer.frameCount) videoPlayer.frame = 0;
            videoPlayer.Play();
        }
    }

    public void Pause(bool paused)
    {
        if (paused)
        {
            videoPlayer.Pause();
            pauseButton.image.color = Color.clear;
        }

        else
        {
            videoPlayer.Play();
            pauseButton.image.color = Color.white;
        }
    }

    public void SliderInteraction()
    {
        videoPlayer.frame = (long)(slider.value * videoPlayer.frameCount);
    }

    private void FixedUpdate()
    {
        if(videoPlayer.isPaused)
        {
            pauseButton.image.sprite = resumeIcon;
            group.alpha = 1;
            group.interactable = true;
            group.blocksRaycasts = true;
            return;
        }

        slider.value = (float)(videoPlayer.time / videoPlayer.clip.length);

        if (gameObject.activeSelf &&
        RectTransformUtility.RectangleContainsScreenPoint(
        gameObject.GetComponent<RectTransform>(),
        Input.mousePosition,
        null))
        {
            group.alpha = 1;
            group.interactable = true;
            group.blocksRaycasts = true;
        } else
        {
            group.alpha = 0;
            group.interactable = false;
            group.blocksRaycasts = false;
        }
    }
}
