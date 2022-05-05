using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Video;
using UnityEngine.UI;

public class OpenVideoPlayer : OpenProgram
{
    [SerializeField] private VideoClip videoClip;
    [SerializeField] private RenderTexture renderTexture;
    [SerializeField] private Vector2 size;
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);

        if (program == null) return;

        RectTransform rt = program.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(size.x + 20, size.y + 70);

        
        VideoPlayer videoPlayer = program.GetComponentInChildren<VideoPlayer>();
        videoPlayer.clip = videoClip;

        RawImage video = program.transform.GetChild(2).GetComponentInChildren<RawImage>();

        videoPlayer.targetTexture = renderTexture;
        video.texture = renderTexture;

        videoPlayer.Play();
    }
}
