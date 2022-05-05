using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    private AudioSource audioSource;

    private bool locked = false;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Exit()
    {
        if (locked) return;
        locked = true;

        StartCoroutine(Shutdown());
    }

    IEnumerator Shutdown()
    {
        audioSource.Play();

        yield return new WaitForSeconds(1.5f);

        Application.Quit();
    }
}
