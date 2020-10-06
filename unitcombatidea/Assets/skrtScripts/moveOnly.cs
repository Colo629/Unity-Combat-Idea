using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class moveOnly : MonoBehaviour
{
    public SteamVR_Action_Vector2 m_MoveValue = null;
    public float maxSpeed;
    public float maxRotation;
    public float acceleration;
    public Rigidbody mechBody;
    public Transform commandPlat;
    public MeshCollider gumDumb;
    public leverScript leverLeft;
    public leverScript leverRight;
    public bool cruiseControl;
    public SteamVR_Action_Single leftMechTrigger;
    public bool triggerCC;
    public bool backsway;
    public bool firstGrab;
    public bool firstCC;
    public bool click1;
    public SteamVR_Action_Vector2 m_RightRotatePress = null;
    public float deadzone;
    public float rotationSpeed;
    public float rotateSens;
    public Transform rotateAroundThis;
    public Transform rotateAroundThis2;
    public float changeElevation;
    public float clampedElevation;
    public float rotateGambit;
    public float upDownAngle;

    // call rigidbody.velocity (vector3)
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        //if(leverRight.grabbed == true)
        //{
            rotateCalculations();
        //}
        if(leverLeft.grabbed == true)
        {
            if(!firstGrab)
            {
                firstCC = false;
                triggerCC = false;
                backsway = false;
                click1 = false; //could be a mistake
                firstGrab = true;
            }
            if(!triggerCC)
            {
                Vector3 localMechDirection = commandPlat.InverseTransformDirection(mechBody.velocity);
                Vector2 mechDirectionV2 = new Vector2(localMechDirection.x,localMechDirection.z);
                Vector2 newDirection = Vector2.Lerp(mechDirectionV2,(m_MoveValue.axis * maxSpeed),(0.8f * Time.deltaTime));
                Vector3 newDirectionV3 = new Vector3(newDirection.x,0,newDirection.y);
                mechBody.velocity = commandPlat.TransformDirection(newDirectionV3);
                cruiseControl = false;
                if(leftMechTrigger.axis >= 0.93f)
                {
                    if(!click1)
                    {
                        triggerCC = true;
                        click1 = true;
                    }              
                }
                if(leftMechTrigger.axis <= 0.7f)
                {
                    if(click1 == true)
                    {
                        click1 = false;
                    }
                    
                }
            }
            if(triggerCC == true)
            {
                if(leftMechTrigger.axis <= 0.7f)
                {
                    backsway = true;
                }
                if(leftMechTrigger.axis >= 0.93f)
                {
                    if(backsway)
                    {
                        firstCC = false;
                        triggerCC = false;
                        backsway = false;   
                    }
                }               
            }
                 
            if(triggerCC == true & !firstCC )
            {
                Vector3 localMechDirection = commandPlat.InverseTransformDirection(mechBody.velocity);
                Vector2 mechDirectionV2 = new Vector2(localMechDirection.x,localMechDirection.z);
                Vector2 newDirection = Vector2.Lerp(mechDirectionV2,(m_MoveValue.axis * maxSpeed),(0.8f * Time.deltaTime));
                Vector3 newDirectionV3 = new Vector3(newDirection.x,0,newDirection.y);
                mechBody.velocity = commandPlat.TransformDirection(newDirectionV3);
                triggerCC = true;
                firstCC = true;
            }
        }
        if(leverLeft.grabbed == false & !cruiseControl)
        {
            Vector3 localMechDirection = commandPlat.InverseTransformDirection(mechBody.velocity);
            Vector2 mechDirectionV2 = new Vector2(localMechDirection.x,localMechDirection.z);
            Vector2 newDirection = Vector2.Lerp(mechDirectionV2,(m_MoveValue.axis * maxSpeed),(0.8f * Time.deltaTime));
            Vector3 newDirectionV3 = new Vector3(newDirection.x,0,newDirection.y);
            mechBody.velocity = commandPlat.TransformDirection(newDirectionV3);
            firstGrab = false;
            triggerCC = false;
            cruiseControl = true;
        }
        

        


    }
    public void rotateCalculations()
    {
        // if(Mathf.Abs(m_RightRotatePress.axis.x)  > deadzone)
        {
            //rotationSpeed = 0;  
        }
       //  if (m_LeftRotatePress.GetStateDown(SteamVR_Input_Sources.RightHand))
        //snapValue = -Mathf.Abs(m_RotateIncrement);
    
        /*if (Mathf.Abs(m_RightRotatePress.axis.y)  > deadzone)
        {
            rotationSpeed = 0; 
        }*/
        if(Mathf.Abs(m_RightRotatePress.axis.x) < deadzone & Mathf.Abs(m_RightRotatePress.axis.y) > deadzone)
        {  
            rotationSpeed = m_RightRotatePress.axis.y * rotateSens;
            rotationSpeed = rotationSpeed * Time.deltaTime;
            changeElevation += rotationSpeed; 
            clampedElevation = Mathf.Clamp(changeElevation,-upDownAngle,upDownAngle);
            if(changeElevation > upDownAngle)
            {
                changeElevation = upDownAngle;
            }
            if(changeElevation < -upDownAngle)
            {
                changeElevation = -upDownAngle;
            }
            commandPlat.localEulerAngles = new Vector3(-clampedElevation,commandPlat.localEulerAngles.y,commandPlat.localEulerAngles.z);
        }
        //if(Mathf.Abs(m_RightRotatePress.axis.y) < deadzone | Mathf.Abs(m_RightRotatePress.axis.x) > deadzone)
        //{   
            //rotationSpeed = m_RightRotatePress.axis.x * rotateSens;
           // rotationSpeed = rotationSpeed * Time.deltaTime;
            Vector3 mechAngularVelocity = mechBody.angularVelocity;
            Vector2 mechAngularVelocityV2 = new Vector2(mechAngularVelocity.x,mechAngularVelocity.z); //might be not x and z
            Vector2 newAngularVelocity = Vector2.Lerp(mechAngularVelocityV2,(new Vector2(m_RightRotatePress.axis.x,0) * maxRotation),(0.8f * Time.deltaTime));
            Vector3 newAngularVelocityV3 = new Vector3(newAngularVelocity.x,0,newAngularVelocity.y);
            transform.RotateAround(rotateAroundThis.position, Vector3.up, newAngularVelocityV3.x); 
            Debug.Log(mechBody.angularVelocity);
            //mechBody.angularVelocity = newAngularVelocityV3;
            
            //VVVVVVVVVVVV    REFERENCE ONLY REFERENCE ONLY REFERENCE ONLY REFERENCE ONLY VVVVVVVVVVVVVVVVVVVVVVVVVVVVV
           /* Vector3 localMechDirection = commandPlat.InverseTransformDirection(mechBody.velocity);
            Vector2 mechDirectionV2 = new Vector2(localMechDirection.x,localMechDirection.z);
            Vector2 newDirection = Vector2.Lerp(mechDirectionV2,(m_MoveValue.axis * maxSpeed),(0.8f * Time.deltaTime));
            Vector3 newDirectionV3 = new Vector3(newDirection.x,0,newDirection.y);
            mechBody.velocity = commandPlat.TransformDirection(newDirectionV3);*/
        //}  
    }
}
