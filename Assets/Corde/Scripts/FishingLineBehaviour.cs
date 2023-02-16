using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingLineBehaviour : MonoBehaviour
{
    public GameObject RopePiece;
    public GameObject parentObject;
    public GameObject FishingLine;

    public int lenght;
    public int count;


    public float partDistance = 0.21f;

    public bool spawn;
    public bool snapFirst;
    public bool snapLast;

    void Update()
    {
        if(spawn == true)
        {
            Spawn();

            spawn = false;
        }
    }


    public void Spawn()
    {
        count = (int)(lenght / partDistance);

        for (int x = 0; x < count; x++)
        {
            FishingLine = Instantiate(RopePiece, new Vector3(transform.position.x, transform.position.y + partDistance * (x + 1), transform.position.z), Quaternion.identity, parentObject.transform);
            FishingLine.transform.eulerAngles = new Vector3(180, 0, 0);

            FishingLine.name = parentObject.transform.childCount.ToString();

            if (x == 0)
            {
                Destroy(FishingLine.GetComponent<CharacterJoint>());
                if (snapFirst)
                {
                    FishingLine.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                }
            }
            else
            {
                FishingLine.GetComponent<CharacterJoint>().connectedBody = parentObject.transform.Find((parentObject.transform.childCount - 1).ToString()).GetComponent<Rigidbody>();
            }

            if (snapLast)
            {
                parentObject.transform.Find((parentObject.transform.childCount).ToString()).GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            }
        }
    }
}