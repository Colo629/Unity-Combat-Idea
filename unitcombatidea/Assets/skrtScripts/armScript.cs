using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class armScript : MonoBehaviour
{
    public leverScript lever; 
    public gunScript pistol;
    public Transform elbow;
    public Transform shoulder;
    public Transform upperArm;
    public bool mirror;
    public SteamVR_Action_Single rightMechTrigger;
    public SteamVR_Action_Single leftMechTrigger;
    // Update is called once per frame
    public bool fireRightGun;
    public bool fireLeftGun;
    public harkenControlScript harkenL;
    public harkenControlScript harkenR;
    
    
    
    
    
    
    
    
    
    void Update()
    
    {
        if (!mirror)
        {
            
            float upperArmAngle = (2 * 90 * lever.output.x) + 93.7f;
            float shoulderAngle = 2 * 180 * lever.output.y / leverScript.multiplier;
            float elbowAngle = -135 * lever.output.z / leverScript.multiplier;
            if(upperArmAngle >= 0)
            {
            shoulder.localEulerAngles = new Vector3(shoulderAngle,0,upperArmAngle); //replace first 0 with shoulderAngle
            }
            elbow.localEulerAngles = new Vector3(elbowAngle,0,0); //replace first 0 with elbowAngle  
       if(upperArmAngle < 0)
       {
           
           shoulder.localEulerAngles = new Vector3(shoulderAngle,-upperArmAngle ,0); //replace first 0 with shoulderAngle
       }
       if(!harkenR.rightHarkArmed == true)
       {
            if(lever.armTriggerR == true)
            {
                if(rightMechTrigger.axis >= 0.7f)
                {
                    fireRightGun = true;
                    Debug.Log("fireRight");
                }
                if(rightMechTrigger.axis < 0.7f)
                {
                    fireRightGun = false;
                    pistol.pistolFiredR = false;
                
                }
            }
        }
        }
        else
        {
            float upperArmAngle = (2 * 90 * lever.output.x) - 93.7f ;
            float shoulderAngle = -2 * 180 * lever.output.y / leverScript.multiplier;
            float elbowAngle = -135 * lever.output.z / leverScript.multiplier;
            if(upperArmAngle <= 0)
            {
            shoulder.localEulerAngles = new Vector3(shoulderAngle,0,upperArmAngle); //replace first 0 with shoulderAngle
            }
            elbow.localEulerAngles = new Vector3(elbowAngle,0,0); //replace first 0 with elbowAngle  
            
        if(upperArmAngle > 0)
        {
            Debug.Log("jjj");
            shoulder.localEulerAngles = new Vector3(shoulderAngle,-upperArmAngle ,0); //replace first 0 with shoulderAngle
        }
        if(!harkenL.leftHarkArmed == true)
        {
            if(lever.armTriggerL == true)
            {
                if(leftMechTrigger.axis >= 0.7f)
                {
                    fireLeftGun = true;
                    Debug.Log("fireLeft");
                }
                if(leftMechTrigger.axis < 0.7f)
                {
                    fireLeftGun = false;
                    pistol.pistolFiredL = false;
                }
            }
        }
        }
    }
}
