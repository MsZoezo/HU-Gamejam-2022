using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PipePuzzleCheck : MonoBehaviour
{
    private int numPijpjes;
    private float[] pijpjesArr;
    private List<float>[] correct;
    private float pijpje;
    private int amountCorrect = 1;
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        numPijpjes = transform.childCount;
        Debug.Log(numPijpjes);
        
        //pijpjesArr = new float[numPijpjes];
        //correct = new List<float>[]
        //{
        //    {-1f}, {-1f}, {-1f}, {-1f}, {-1f}, { 0f, 180f }
        //};

    }

    public void Correct()
    {
        amountCorrect += 1;

        Debug.Log(amountCorrect);

        if(amountCorrect == numPijpjes)
        {
            Debug.Log("Winner!");
        }
    }

    public void Wrong()
    {
        amountCorrect -= 1;
        Debug.Log(amountCorrect);
    }

    public void Check()
    {





        //int i = 0;
        //foreach (Transform child in transform)
        //{
        //    pijpje = child.rotation.eulerAngles.z;
        //    pijpjesArr[i] = pijpje;
        //    i++;
        //}

        //bool isEqual = false;
        //for(int index = 0; index < pijpjesArr.Length; index++) {
        //    float[] arr = correct[index];

        //    foreach(float correctRotation in arr)
        //    {
        //        if(correctRotation == pijpjesArr[index])
        //        {
        //            isEqual = true;
        //            continue;
        //        }

        //        isEqual = false;
        //    }

        //    if (!isEqual) return;
        //}

        //bool isEqual = Enumerable.SequenceEqual(correct, pijpjesArr);
        //if (isEqual)
        //{
        //    foreach (Transform child in transform)
        //    {
        //        Destroy(child.gameObject);
        //    }
        //}


        ///// <summary>
        ///// 
        ///// 0 tm 4 maken niet uit
        ///// 0 of 180,90,180,180,90,
        ///// 180, 0, 0 , 0, 90 of -90,
        ///// 90 of -90, 180, 0, 180, 0,
        ///// -90, 0, maakt niet uit, -90, 0
        ///// 
        ///// </summary>
        //for (int p = 0; p < pijpjesArr.Length; p++)
        //{
        //    switch (p)
        //    {
        //        case 5 :
        //            if (pijpjesArr[p] == 0 || pijpjesArr[p] == 180)
        //            {
        //                continue;
        //            }
        //            else
        //            {
        //                break;
        //            }

        //        case 6:
        //            if (pijpjesArr[p] == 90)
        //            {
        //                continue;
        //            } else
        //            {
        //                break;
        //            }

        //        case 7:
        //            if(pijpjesArr[p] == 180)
        //            {
        //                continue;
        //            } else
        //            {
        //                break;
        //            }

        //        case 8:
        //            if (pijpjesArr[p] == 180)
        //            {
        //                continue;
        //            } else
        //            {
        //                break;
        //            }

        //        case 9:
        //            if (pijpjesArr[p] == 90)
        //            {
        //                continue;
        //            }
        //            else
        //            {
        //                break;
        //            }

        //        case 10:
        //            if (pijpjesArr[p] == 180)
        //            {
        //                continue;
        //            }
        //            else
        //            {
        //                break;
        //            }

        //        case 11:
        //            if (pijpjesArr[p] == 0)
        //            {
        //                continue;
        //            }
        //            else
        //            {
        //                break;
        //            }

        //        case 12:
        //            if (pijpjesArr[p] == 0)
        //            {
        //                continue;
        //            }
        //            else
        //            {
        //                break;
        //            }
        //    }
            
        //}
    }
}
