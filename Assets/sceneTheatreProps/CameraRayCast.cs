using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class CameraRayCast : MonoBehaviour
{
    public Ray ray;
    public RaycastHit hit;

    public GameObject Levier;

    public bool open;

    public void Start()
    {
        Debug.Log("YES");
    }

    public void Update()
    {
        if(open == false)
        {
            Levier.transform.GetComponent<FishingrodCast>().enabled = false;
        }

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 20, Color.red);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "Levier")
            {
                hit.transform.GetComponent<FishingrodCast>().enabled = true;
            }

            if (hit.transform.GetComponent<FishingrodCast>().IsFishingrodBackward == true && hit.transform.GetComponent<FishingrodCast>().IsFishingrodForward == false)
            {
                open = true;
            }
            else
            {
                open = false;
            }
        }
    }
}
