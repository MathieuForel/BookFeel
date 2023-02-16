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

    public float sec;

    public void Start()
    {
        Debug.Log("YES");
    }

    public void Update()
    {
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

    }
}
