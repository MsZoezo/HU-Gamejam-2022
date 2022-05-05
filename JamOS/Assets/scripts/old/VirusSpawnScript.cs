using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VirusSpawnScript : MonoBehaviour
{
    [SerializeField] GameObject prefab1;
    [SerializeField] GameObject prefab2;
    [SerializeField] GameObject prefab3;
    private GameObject parent;

    private int virusCounter;
    private int aantalVirus;
    
    private GameObject[] viruses;
    private void Start()
    {
        parent = GameObject.Find("Virus ding");
        viruses = new GameObject[] {prefab1, prefab2, prefab3};
    }
    public void SpawnVirus()
    {
        int index = Random.Range(0, viruses.Length);
        RectTransform rt = viruses[index].GetComponent<RectTransform>();

        float x = Random.Range(0 + (rt.rect.width / 2), Screen.width - (rt.rect.width / 2));
        float y = Random.Range(0 + (rt.rect.height / 2), Screen.height - (rt.rect.height / 2));

        var gameobj = Instantiate(viruses[index], new Vector3(x, y), Quaternion.identity);
        gameobj.transform.SetParent(parent.transform);
    }

    public void StartVirusLoop()
    {
        StartCoroutine(VirusLoop());
    }

    IEnumerator VirusLoop()
    {
        for(int i = virusCounter; i < 4; i++)
        {
            SpawnVirus();
            aantalVirus = parent.transform.childCount;
            float wacht = Random.Range(0.5f, 2);
            yield return new WaitForSeconds(wacht);
        }

        while(aantalVirus > 4)
        {
            SpawnVirus();
            aantalVirus = parent.transform.childCount;
            float wacht = Random.Range(0.5f, 3);

            yield return new WaitForSeconds(wacht);
        }
    }
}