using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryController : Singleton<StoryController>
{
    public int act = 1;
    public GameObject scene1Obj, scene2Obj, scene3Obj, scene4Obj, scene5Obj;
    public List<int> nbPositionNeeded;
    public int nbValidatedStep = 0;

    public AudioSource audioSource;
    public AudioClip son;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Next();
    }
    public void CheckNextAct()
    {
        nbValidatedStep++;
        if (nbPositionNeeded[act -1] != nbValidatedStep)
        {
            return;
        }

        act++;
        nbValidatedStep = 0;
        Next();
    }
    public void Next()
    {
        if (son != null) audioSource.PlayOneShot(son);
        switch (act)
        {
            case 1:
                scene1Obj.SetActive(true);
                break; 

            case 2:
                scene1Obj.SetActive(false);
                scene2Obj.SetActive(true);
                break; 

            case 3:
                scene2Obj.SetActive(false);
                scene3Obj.SetActive(true);
                break; 

            case 4:
                scene3Obj.SetActive(false);
                scene4Obj.SetActive(true);
                break; 

            case 5:
                scene4Obj.SetActive(false);
                scene5Obj.SetActive(true);
                break;


            default:
                break;
        }
    }
}
