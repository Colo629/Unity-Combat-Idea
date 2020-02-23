using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TouchGestures : MonoBehaviour
{
    public SteamVR_Action_Vector2 radialSelector;

    public SteamVR_Action_Boolean padClickLeft;
    public SteamVR_Action_Boolean padClickRight;

    public float sqrThreshold = 0.04f;

    public Transform leftHand;
    public Transform rightHand;


    void Start()
    {

    }

    void Update()
    {
        
    }


    private bool listenCondition()
    {
        if ((leftHand.position - rightHand.position).sqrMagnitude < sqrThreshold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    private void GestureLoop()
    {
        Vector2 rightPad = radialSelector.GetAxis(SteamVR_Input_Sources.RightHand);
        Vector2 leftPad = radialSelector.GetAxis(SteamVR_Input_Sources.LeftHand);

        if (padClickLeft.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            Debug.Log(GeoDetect.hexalPadCalc(GeoDetect.calcPadTheta(leftPad.x, leftPad.y)));
        }

        if (padClickRight.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            Debug.Log(GeoDetect.hexalPadCalc(GeoDetect.calcPadTheta(rightPad.x, rightPad.y)));
        }
    }
}

