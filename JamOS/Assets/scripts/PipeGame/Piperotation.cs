using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Piperotation : MonoBehaviour, IPointerClickHandler
{
    private PipePuzzleCheck pipePuzzleCheck;

    private float[] rotations = { 0, 90, 180, 270, -90, -180};

    [SerializeField] float[] corrRot;
    public bool correct = false;

    int PossRot;



    // Start is called before the first frame update
    void Start()
    {
        pipePuzzleCheck = FindObjectOfType<PipePuzzleCheck>().transform.GetComponent<PipePuzzleCheck>();

        PossRot = corrRot.Length;
        int rand = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0, 0, rotations[rand]);

        if (PossRot == 2)
        {
            if (transform.eulerAngles.z == corrRot[0] || transform.eulerAngles.z == corrRot[1])
            {
                correct = true;
                pipePuzzleCheck.Correct();
            }
        } 
        else if (PossRot == 4)
        {
            if (transform.eulerAngles.z == corrRot[0] || transform.eulerAngles.z == corrRot[1] || transform.eulerAngles.z == corrRot[2] || transform.eulerAngles.z == corrRot[3])
            {
                correct = true;
                pipePuzzleCheck.Correct();
            }
        }
        else
        {
            if (transform.eulerAngles.z == corrRot[0])
            {
                correct = true;
                pipePuzzleCheck.Correct();
            }
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        transform.Rotate(new Vector3(0,0,90));
        if (PossRot == 2)
        {
            if (transform.eulerAngles.z == corrRot[0] || transform.eulerAngles.z == corrRot[1] && correct == false)
            {
                correct = true;
                pipePuzzleCheck.Correct();
            }
            else if (correct == true)
            {
                correct = false;
                pipePuzzleCheck.Wrong();
            }
        }
        else if (PossRot == 4)
        {
            if ((transform.eulerAngles.z == corrRot[0] || transform.eulerAngles.z == corrRot[1] || transform.eulerAngles.z == corrRot[2] || transform.eulerAngles.z == corrRot[3]) && correct == false)
            {
                correct = true;
                pipePuzzleCheck.Correct();
            }

        }
        else
        {
            if (transform.eulerAngles.z == corrRot[0] && correct == false)
            {
                correct = true;
                pipePuzzleCheck.Correct();
            }
            else if (correct == true)
            {
                correct = false;
                pipePuzzleCheck.Wrong();
            }
        }

        //pipePuzzleCheck.Check();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
