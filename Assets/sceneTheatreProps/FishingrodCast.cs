using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingrodCast : MonoBehaviour
{
    public float FishingrodVelocity;
    public float FishingrodSpeed;
    public float FishingrodDistance;
    public float FishingrodMaxDistance;
    public float Multiplicator;
    public bool IsFishingrodBackward;
    public bool IsFishingrodForward;
    public bool FirstCheck;
    public bool ActCheck;
    public float FirstTime;
    public float FishingrodRotation;

    public GameObject _Left;
    public GameObject _Right;

    public GameObject _PivotPoint;

    public void Start()
    {
        _PivotPoint = this.gameObject.transform.GetChild(0).gameObject;
    }

    public void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Casting();
        }

        if (StoryController.Instance.CheckIfActIsFinished() && ActCheck == false)
        {
            IsFishingrodForward = false;
            IsFishingrodBackward = false;
            FirstCheck = false;
            ActCheck = true;
        }

        if(IsFishingrodBackward == true && IsFishingrodForward == false)
        {
            _Left.GetComponent<Move>().A = true;
            _Right.GetComponent<Move>().A = true;
            Multiplicator = 0;
            FishingrodDistance += 11 * FirstTime * Time.deltaTime;
            Casting();

            if(FirstCheck == false)
            {
                StoryController.Instance.WantNextAct();
                    FirstCheck = true;
            }

        }
        else
        {
            Multiplicator = 1000;
            _Left.GetComponent<Move>().A = false;
            _Right.GetComponent<Move>().A = false;
        }

        
        if (FishingrodDistance >= FishingrodMaxDistance / 2 && IsFishingrodBackward == true)
        {
            IsFishingrodForward = true;
        }


        if (IsFishingrodForward == true)
        {
            _PivotPoint.transform.rotation = Quaternion.Euler(Mathf.Clamp(FishingrodRotation * FishingrodDistance, -15, 15), 0, 0);
            ActCheck = false;
            FirstTime = 1f;
        }
    }

    public void Casting()
    {
        FishingrodVelocity = (Input.GetAxis("Vertical") * Multiplicator) / (Screen.width * Screen.height);

        FishingrodDistance += FishingrodVelocity * FishingrodSpeed;
        FishingrodDistance = Mathf.Clamp(FishingrodDistance, -FishingrodMaxDistance, FishingrodMaxDistance);

        //Debug.Log(FishingrodDistance);

        Debug.Log(Input.GetAxis("Vertical"));

        _PivotPoint.transform.rotation = Quaternion.Euler(Mathf.Clamp(FishingrodRotation * FishingrodDistance, -90, 25), 0, 0);

        if (IsFishingrodBackward == false)
        {
            if (FishingrodDistance < -FishingrodMaxDistance/1.5f)
            {
                IsFishingrodBackward = true;
            }
        }
        
        if(FishingrodDistance >= FishingrodMaxDistance/2 && IsFishingrodBackward == true)
        {
            IsFishingrodForward = true;

        }

        if(IsFishingrodForward == true) 
        {
            _PivotPoint.transform.rotation = Quaternion.Euler(Mathf.Clamp(FishingrodRotation * FishingrodDistance, -15, 15), 0, 0);
            FishingrodDistance = Mathf.Clamp(FishingrodDistance, -5, 5);
        }
    }
}
