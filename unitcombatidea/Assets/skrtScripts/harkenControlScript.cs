using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class harkenControlScript : MonoBehaviour
{
    public Transform harkenHolderL;
    public Transform harkenHolderR;
    public SteamVR_Action_Vector2 leftHarkenInput;
    public SteamVR_Action_Vector2 rightHarkenInput;
    public bool leftController;
    public bool rightController;
    public leverScript leverScriptL;
    public leverScript leverScriptR;
    public float deadzone = 0f;
    public float rotateSensX = 45f;
    public float rotateSensY = 45f;
    public float harkenRotationX = 0f;
    public float harkenRotationY = 0f;
    public SteamVR_Action_Boolean armLeftHarken;
    public SteamVR_Action_Boolean armRightHarken;
    public SteamVR_Input_Sources leftHand;
    public SteamVR_Input_Sources rightHand;
    public SteamVR_Action_Single fireRightHarkenTrigger;
    public SteamVR_Action_Single fireLeftHarkenTrigger;
    public grapplingHook grapplingHookL;
    public grapplingHook grapplingHookR;
    public bool rightHarkArmed;
    public bool leftHarkArmed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(leftController == true)
        {
            if(leverScriptL.grabbed == true)
            {
            if(!grapplingHookL.hookedL)
            {
                if(armLeftHarken.GetStateDown(leftHand))
                {
                    leftHarkArmed = true;
                }
             
                if(armLeftHarken.GetStateUp(leftHand))
                {
                    leftHarkArmed = false;
                }
                leftHarkenFunction();
            }
            if(grapplingHookL.hookedL)
            {
                leftHarkArmed = false;
            }
            }
        }
        if(rightController == true)
        {
            if(leverScriptR.grabbed == true)
            {
                if(!grapplingHookR.hookedR)
                {
                    if(armRightHarken.GetStateDown(rightHand))
                    {
                        rightHarkArmed = true;
                    }
                
                if(armRightHarken.GetStateUp(rightHand))
                {
                    rightHarkArmed = false;
                }
                rightHarkenFunction();
                }   
                if(grapplingHookR.hookedR)
                {
                    rightHarkArmed = false;
                }
            }
        }
    }
    private void leftHarkenFunction()
    { 
    float harkenAngleX = leftHarkenInput.axis.x *  rotateSensX;
    float harkenAngleY = leftHarkenInput.axis.y * rotateSensY;
    harkenHolderL.localEulerAngles = new Vector3(Mathf.Clamp(harkenAngleY ,-100,100),Mathf.Clamp(harkenAngleX,-100,100),0);
    if(leftHarkArmed == true)
    {
        Debug.Log("armedlefthand");
        if(fireLeftHarkenTrigger.axis >= 0.7f)
        {
            grapplingHookL.firedL = true;
        }
    }
   

    }
    private void rightHarkenFunction()
    {
    float harkenAngleX = rightHarkenInput.axis.x * rotateSensX;
    float harkenAngleY = rightHarkenInput.axis.y * rotateSensY;
    harkenHolderR.localEulerAngles = new Vector3(Mathf.Clamp(harkenAngleY,-100,100),Mathf.Clamp(harkenAngleX,-100,100),0);
    if(rightHarkArmed == true)
    {
        Debug.Log("armedRightHand");
        if(fireRightHarkenTrigger.axis >= 0.7f)
            {
                grapplingHookR.firedR = true;
            }
        
    }
    }
}
