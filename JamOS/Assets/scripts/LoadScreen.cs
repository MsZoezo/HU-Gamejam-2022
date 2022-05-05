using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScreen : MonoBehaviour
{
    private Slider loadingBar;
    private int percent = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        loadingBar = transform.GetComponent<Slider>();
        StartCoroutine(StartLoader());
    }

    IEnumerator StartLoader()
    {
        float wacht = Random.Range(0.01f, 0.15f);
        
        for(int i = percent; percent < 25; i++)
        {
            loadingBar.value = i;
            
            percent++;
            yield return new WaitForSeconds(wacht);
        }

        wacht = Random.Range(0.15f, 0.30f);

        for (int i = percent; percent < 35; i++)
        {
            loadingBar.value = i;

            percent++;
            yield return new WaitForSeconds(wacht);
        }

        wacht = Random.Range(0.01f, 0.05f);

        for (int i = percent; percent < 70; i++)
        {
            loadingBar.value = i;

            percent++;
            yield return new WaitForSeconds(wacht);
        }

        wacht = 0.05f;

        for (int i = percent; percent < 100; i++)
        {
            loadingBar.value = i;

            percent++;
            yield return new WaitForSeconds(wacht);
        }

        SceneManager.LoadScene("Login");

    }

    
}
