using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class swordScript : MonoBehaviour
{
    /*public leverScript leverL;
    public leverScript leverR;
    public Transform swordHandle;
    public bool leftHand;
    Vector3 handleMovement;
    public float multiplier =10;
    public Transform mech;
    public Vector3 relativePosition;
    public Transform rotateRef;*/
    public bool rightHand;
    public leverScript leverR;
    public Transform swordHandle;
    public Transform mech;
    public Vector3 relativePosition;
    public Transform rotateRef;
    public bool stabSwitch;
    public float multiplier = 1;
    public Vector3 relativeRotation2;
    public bool cocked;
    public bool fired;
    public bool firing;
    public Vector3 stabReset;
    public Vector3 slashReset;
    public bool firstSlash;
    public bool firstStab;
    public Vector3 stabReset2;
    public SteamVR_Action_Single rightMechTrigger;
    public bool doublePull;
    public Vector3 handleMovement;
    public Transform hannibalsGambit;
    public bool setAngle = false;
    public bool hammerDown = false;
    public bool activateSword;
    public bool endAttack;
    public float switchPos;
    public bool recordSwitch;
    public bool renderOff;
    public bool wentBack;
    public bool slashAttack;
    public bool stabAttack;
    public bool gettingSpawned;
    public bool gettingDespawned;
    public Transform resetPoint;
    public SteamVR_Action_Vector2 m_RightRotatePress = null;
    public float deadzone;
    public float rotationSpeed;
    public float rotateSens;
    public Transform rotateAroundThis;
    public float elevation;
    public float changeElevation;
    public float clampedElevation;
    



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   
   void Update()
   {        
            
            if(gettingSpawned == true)
            {
                gettingSpawnedFR();
            }
            if(gettingDespawned == true)
            {
                gettingDespawnedFR();
            }
            if(activateSword == true)
            {
                fireSolution();
                //manageElevation();
            }
            if(activateSword == false)
            {
                stabSwitch = false;
                cocked = false;
                fired = false;
                firing = false;
                firstSlash = false;
                firstStab = false;
                doublePull = false;
                setAngle = false;
                hammerDown = false;
                slashAttack = false;
                stabAttack = false;
                endAttack = false;
                switchPos = 0f;
                recordSwitch = false;
            }
            if(leverR.grabbed == true & activateSword == true)
            {
                stabSwitchProtocol();
            
                if(!stabSwitch)
                {
                    rightHandSlash();
                }
                if(stabSwitch)
                {
                    rightHandStab();
                }
            }
   }
   public void gettingSpawnedFR()
   {
    swordHandle.localEulerAngles = new Vector3(0,0,0);
    rotateRef.localEulerAngles = new Vector3(0,0,0);
    hannibalsGambit.localEulerAngles = new Vector3(0,-90f,0);
    clampedElevation = 0;
    changeElevation = 0;
    //hannibalsGambit.position = new Vector3(0,0,0);
    //swordHandle.position = new Vector3(0,0,0);
    //rotateRef.position = new Vector3(0,0,0);
    gettingSpawned = false;
   }
   public void gettingDespawnedFR()
   {
    swordHandle.localEulerAngles = new Vector3(0,0,0);
    rotateRef.localEulerAngles = new Vector3(0,0,0);
    hannibalsGambit.localEulerAngles = new Vector3(0,0,0);
    clampedElevation = 0;
    changeElevation = 0;
    //hannibalsGambit.position = new Vector3(0,0,0);
    //swordHandle.position = new Vector3(0,0,0);
    //rotateRef.position = new Vector3(0,0,0);
    
    gettingDespawned = false;
   }
    void rightHandSlash()
   {
       if(!firstSlash)
       {
           slashResetProtocol();
       }
        float zValue = (leverR.output.z * multiplier * 1.5f) - 40f; //push/pull
        float yValue = (leverR.output.y * multiplier); //lateral movement
        float xValue = (leverR.output.x * (multiplier/1.1f)) - 60f; //rotate
        
        if(rightMechTrigger.axis <=0.89f)
        {
            hammerDown = false;
        }
        if(hammerDown == true & rightMechTrigger.axis >= 0.90f)
        {
            if(!setAngle)
            {
                swordHandle.localEulerAngles = new Vector3(0,0,xValue);
                rotateRef.localEulerAngles = new Vector3(-zValue,0,0);
                setAngle = true;
            }
            rotateRef.localEulerAngles = new Vector3(-zValue,0,0);
            
        }
        if(!hammerDown)
        {
            setAngle = false;
            swordHandle.localEulerAngles = new Vector3(0,0,xValue);
            rotateRef.localEulerAngles = new Vector3(-zValue,0,0);
        }
        
        
           /* Vector3 relativeRotation = new Vector3(0,0,xValue);
            relativeRotation = mech.TransformDirection(relativeRotation);
            swordHandle.localEulerAngles = relativeRotation;
            
            relativeRotation2 = new Vector3(-zValue,0,0);
            relativeRotation2 = mech.TransformDirection(relativeRotation2);
            rotateRef.localEulerAngles = relativeRotation2;*/

   }
   public void rightHandStab()
   {
       if(!firstStab)
       {
           stabResetProtocol();
       }
        float zValue = (leverR.output.z * multiplier/50); //push/pull
        float yValue = (leverR.output.y * multiplier);
        float xValue = (leverR.output.x * multiplier); //rotate\
        handleMovement = new Vector3(0,0,-zValue);
        handleMovement = rotateRef.TransformPoint(handleMovement);
        hannibalsGambit.position = handleMovement;
   }

  public void slashResetProtocol()
   {    
    handleMovement = new Vector3(0,0,0);
    handleMovement = rotateRef.TransformPoint(handleMovement);
    hannibalsGambit.position = handleMovement;
    swordHandle.localEulerAngles = new Vector3(0,0,0);
    firstSlash = true;
   }

  public void stabResetProtocol()
   {
    /*swordHandle.localEulerAngles = new Vector3(0,0,0);
    rotateRef.localEulerAngles = new Vector3(0,0,0);
    Debug.Log("resestStab");*/
    firstStab = true;
   }

    public void fireSolution()
    {
        if(rightMechTrigger.axis < 0.90f & !stabSwitch)
        {
            //stabswitch = true means we're stabbing 
            cocked = false;
            firing = false;
            hammerDown = false;
            endAttack = false;
            stabAttack = false;
            slashAttack = false;
        }
        if(leverR.output.z > 0.20f & rightMechTrigger.axis >= 0.90f)
        {
            cocked = true;
        }
        if(leverR.output.z > 0.20f & stabSwitch)
        {
            wentBack = true;
            cocked = true;
        }
        if(leverR.output.z <= 0.17f)
        {
            if(cocked == true)
            {
                if(rightMechTrigger.axis >= 0.90f & !stabSwitch)
                {
                    slashAttack = true;
                    firing = true;
                    cocked = false;
                } 
                if(stabSwitch)
                {
                    stabAttack = true;
                    firing = true;
                    cocked = false;
                }
            }
            
        }
        if(cocked == true)
        {
            if(leverR.output.z < 0.20f)
            {
                if(stabSwitch)
                {
                    hammerDown = true;
                }
                if(rightMechTrigger.axis >= 0.90f)
                {
                    hammerDown = true;
                }  
            }
        }
        if(leverR.output.z == 0)
        {   
            hammerDown = false;
            cocked = false;
            firing = false;
            doublePull = true;
            slashAttack = false;
            if(stabSwitch == true & wentBack == true)
            {
                stabAttack = false;
                endAttack = true;
            }
        }
    }
    
    public void manageElevation()
    {
        if(Mathf.Abs(m_RightRotatePress.axis.x) < deadzone & Mathf.Abs(m_RightRotatePress.axis.y) > deadzone)
        {  
            rotationSpeed = m_RightRotatePress.axis.y * rotateSens;
            rotationSpeed = rotationSpeed * Time.deltaTime;
            changeElevation += rotationSpeed; 
            clampedElevation = Mathf.Clamp(changeElevation,-1,1);
            if(changeElevation > 1)
            {
                changeElevation = 1f;
            }
            if(changeElevation < -1)
            {
                changeElevation = -1f;
            }
        }
    }
    public void stabSwitchProtocol()
   {
      // if(leverR.output.z <= 0.08f & leverR.output.z >= 0.06f)
      if(leverR.output.z <= 0.16f & leverR.output.z >= 0.02f)
       {
        if(rightMechTrigger.axis >= 0.90f)
       {
           if(!doublePull)
           {
                if(!stabSwitch)
                {
                    if(!hammerDown)
                    {
                        if(!recordSwitch)
                        {
                            switchPos = leverR.output.z;
                            recordSwitch = true;
                        }
                        Debug.Log("switchtostab");
                        stabSwitch = true;
                        doublePull = true;
                        cocked = false;
                        fired = false;
                        firing = false;
                    }
                    
                }
               
            }
       }
       }
       if(rightMechTrigger.axis < 0.20f)
       {
           doublePull = false;
       }
       if(stabSwitch)
       {
           if(endAttack)
           {  
               if(leverR.output.z >= switchPos & wentBack == true)
               {
                    wentBack = false;
                    firstSlash = false;
                    recordSwitch = false;
                    cocked = false;
                    fired = false;
                    doublePull = true;
                    stabSwitch = false;
                    firing = false;
                    endAttack = false;
               }
           }
       }
                
   }


   
   
    /*void Update()
    {
        if(!leftHand)
        {
            rightHandMovement();
        }
        if(leftHand)
        {
            leftHandMovement();
        }
    
    }
    public void rightHandMovement()
    {
        float xValue = (leverR.output.x * multiplier * 1.5f ) + 2.5f;
        float yValue = (leverR.output.y * multiplier * 3) + 0f;
        float zValue = (leverR.output.z * multiplier *3) + 2.3f;
        handleMovement = new Vector3(yValue,zValue,xValue);
        handleMovement = mech.TransformPoint(handleMovement);
        swordHandle.position = handleMovement;
        
        
        //transform.position = reference.transform.TransformPoint(new Vector3(0,output.y,output.z)); //moves the aesthetics?

    }

    public void leftHandMovement()
    {
        float xValue2 = (leverL.output.x * multiplier / 2);
        float yValue2 = (leverL.output.y * multiplier);
        float zValue2 = (leverL.output.z * multiplier);
        Vector3 relativeRotation = new Vector3(zValue2,-yValue2,xValue2);
        relativeRotation = mech.TransformDirection(relativeRotation);
        swordHandle.localEulerAngles = relativeRotation;
    }*/
}
