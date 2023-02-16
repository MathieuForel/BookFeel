using System;
using System.Collections;
using System.Collections.Generic;
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
        Levier.transform.GetComponent<FishingrodCast>().enabled = false;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 20, Color.red);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "Levier")
            {
                hit.transform.GetComponent<FishingrodCast>().enabled = true;
            }
            else
            {
                Levier.transform.GetComponent<FishingrodCast>().enabled = false;
            }
        }

        if (Levier.transform.GetComponent<FishingrodCast>().IsFishingrodBackward == true && Levier.transform.GetComponent<FishingrodCast>().IsFishingrodForward == false)
        {
            Levier.transform.GetComponent<FishingrodCast>().enabled = true;
        }
    }
}
