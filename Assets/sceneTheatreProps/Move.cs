using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 Vectorx;
    public float f;
    public float fif;
    public float distance;
    public float NPos;
    public bool Left;
    private float lft;
    public float growth;
    public bool A;
    // Start is called before the first frame update
    void Start()
    {
        if (Left)
        {
            lft = -1;
        }
        else
        {
            lft = 1;
        }

        growth = 0;
        f = 0;
        fif = -3;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vectorx.Set(distance + NPos, 0, 0);
        gameObject.transform.position = Vectorx;

        f = f + 1 * Time.deltaTime;

        distance = Mathf.Cos(f) * lft;


        /*
        if (Input.anyKey)
        {
            A = true;
        }
        else
        {
            A = false;
        }*/

        if (growth > -35 && A == true)
        {
            fif = fif - (float)1 * Time.deltaTime;
        }
        
        growth = Mathf.Cos(fif) * 32;
        NPos = growth * lft + 30 * lft;

        if (growth <= -35)
        {
            fif = -3;
            A = false;
            growth = (float)-34.9;
        }
    }

}
