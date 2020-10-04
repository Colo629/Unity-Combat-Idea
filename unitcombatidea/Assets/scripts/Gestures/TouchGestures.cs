using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TouchGestures : MonoBehaviour
{
    public SteamVR_Action_Vector2 radialSelector;

    public SteamVR_Action_Boolean padClickLeft;
    public SteamVR_Action_Boolean padClickRight;
    public SteamVR_Action_Single rSqueeze;
    public SteamVR_Action_Single lSqueeze;
    public fingerGestureScript rightHandGesture;
    public fingerGestureScript leftHandGesture;

    public static int leftValue = -1;
    public static int rightValue = -1;

    public float sqrThreshold = 0.04f;

    public Transform leftHand;
    public Transform rightHand;

    // 00: wall, 04: spear, 61: sword, 60: sword attack, 54: ground spikes, 40: spear attack
    // k chief, call TouchGestures.GestureValue() from anywhere for the number
    // things might be a bit fucky with mirroring, but IDC
    
    void Start()
    {

    }

    void Update()
    {
        // use >0.6 to lock in symbol

        if (listenCondition())
        {
            GestureLoop();
        }
        else
        {
            /*  // TODO: add time delay to deactivation of hands
            leftValue = -1;
            rightValue = -1;
            */
        }
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
        leftValue = leftHandGesture.summonNumberL;
        rightValue = rightHandGesture.summonNumberR;
        /*
        Vector2 rightPad = radialSelector.GetAxis(SteamVR_Input_Sources.RightHand);
        Vector2 leftPad = radialSelector.GetAxis(SteamVR_Input_Sources.LeftHand);

        if (padClickLeft.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            
            leftValue = GeoDetect.hexalPadCalc(GeoDetect.calcPadTheta(-leftPad.x, leftPad.y));
        }

        if (padClickRight.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            
            rightValue = GeoDetect.hexalPadCalc(GeoDetect.calcPadTheta(rightPad.x, rightPad.y));
        }*/
    }

    public static int GestureValue()
    {
        return (leftValue * 10) + rightValue;
    }
}

