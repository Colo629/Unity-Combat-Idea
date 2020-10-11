using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class moveOnly : MonoBehaviour
{
    public MechStatusHolder msh;
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
    public bool airborne = true;
    public bool airborneReset;
    public bool firstAirborne;
    public Transform uiLevel;
    public Transform levelHolder;
    public ejectorLeverScript els;
    public bool spawning;
    public bool doubleOnce;
    public Vector3 newDirectionV3Value;
    public bool outOfFuel;

    // call rigidbody.velocity (vector3)
    
    // Start is called before the first frame update
    void Start()
    {
       mechBody.useGravity = true;
    }

    // Update is called once per frame
    void Update()
    { 
        if(Mathf.Abs(newDirectionV3Value.x) > 0.1 | Mathf.Abs(newDirectionV3Value.y) > 0.1 | Mathf.Abs(newDirectionV3Value.z) > 0.1)
        {
            FuelConsumption();
        }
        if(spawning)
        {
            mechBody.useGravity = false;
        }
        armorChanges();
        //if(leverRight.grabbed == true)
        {
            rotateCalculations();
        }
        airborneCalculations();
        if(leverLeft.grabbed == true )
        {
            if(!firstGrab)
            {
                firstCC = false;
                triggerCC = false;
                backsway = false;
                click1 = false; //could be a mistake
                firstGrab = true;
            }
            if(!airborneReset)
            {
                firstCC = false;
                triggerCC = false;
                backsway = false;
                click1 = false;
                airborneReset = true;
            }
            if(!triggerCC & !airborne & !outOfFuel)
            {
                Vector3 localMechDirection = commandPlat.InverseTransformDirection(mechBody.velocity);
                Vector2 mechDirectionV2 = new Vector2(localMechDirection.x,localMechDirection.z);
                Vector2 newDirection = Vector2.Lerp(mechDirectionV2,(m_MoveValue.axis * maxSpeed),(0.8f * Time.deltaTime));
                Vector3 newDirectionV3 = new Vector3(newDirection.x,0,newDirection.y);
                mechBody.velocity = commandPlat.TransformDirection(newDirectionV3);
                cruiseControl = false;
                newDirectionV3Value = newDirectionV3;
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
                 
            if(triggerCC == true & !firstCC & !airborne & !outOfFuel)
            {
                Vector3 localMechDirection = commandPlat.InverseTransformDirection(mechBody.velocity);
                Vector2 mechDirectionV2 = new Vector2(localMechDirection.x,localMechDirection.z);
                Vector2 newDirection = Vector2.Lerp(mechDirectionV2,(m_MoveValue.axis * maxSpeed),(0.8f * Time.deltaTime));
                Vector3 newDirectionV3 = new Vector3(newDirection.x,0,newDirection.y);
                mechBody.velocity = commandPlat.TransformDirection(newDirectionV3);
                newDirectionV3Value = newDirectionV3;
                triggerCC = true;
                firstCC = true;
            }
            if(!firstAirborne & airborne)
            {
               // Vector3 localMechDirection = commandPlat.InverseTransformDirection(mechBody.velocity);
                //Vector2 mechDirectionV2 = new Vector2(localMechDirection.x,localMechDirection.z);
               // Vector2 newDirection = Vector2.Lerp(mechDirectionV2,(m_MoveValue.axis * maxSpeed),(0.8f * Time.deltaTime));
                //Vector3 newDirectionV3 = new Vector3(newDirection.x,mechBody.velocity.y,newDirection.y);
                mechBody.velocity = commandPlat.TransformDirection(mechBody.velocity);
                firstAirborne = true;
            }
            if(outOfFuel == true)
            {
                Vector3 localMechDirection = commandPlat.InverseTransformDirection(mechBody.velocity);
                Vector2 mechDirectionV2 = new Vector2(localMechDirection.x,localMechDirection.z);
                Vector2 newDirection = Vector2.Lerp(mechDirectionV2,(m_MoveValue.axis * 0f),(0.8f * Time.deltaTime));
                Vector3 newDirectionV3 = new Vector3(newDirection.x,0,newDirection.y);
                mechBody.velocity = commandPlat.TransformDirection(newDirectionV3);
                newDirectionV3Value = newDirectionV3;
            }
        }
        if(leverLeft.grabbed == false & !cruiseControl & !airborne & !outOfFuel)
        {
            Vector3 localMechDirection = commandPlat.InverseTransformDirection(mechBody.velocity);
            Vector2 mechDirectionV2 = new Vector2(localMechDirection.x,localMechDirection.z);
            Vector2 newDirection = Vector2.Lerp(mechDirectionV2,(m_MoveValue.axis * maxSpeed),(0.8f * Time.deltaTime));
            Vector3 newDirectionV3 = new Vector3(newDirection.x,0,newDirection.y);
            mechBody.velocity = commandPlat.TransformDirection(newDirectionV3);
            newDirectionV3Value = newDirectionV3;
            firstGrab = false;
            triggerCC = false;
            cruiseControl = true;
        }
         if(outOfFuel == true)
            {
                Vector3 localMechDirection = commandPlat.InverseTransformDirection(mechBody.velocity);
                Vector2 mechDirectionV2 = new Vector2(localMechDirection.x,localMechDirection.z);
                Vector2 newDirection = Vector2.Lerp(mechDirectionV2,(m_MoveValue.axis * 0f),(0.8f * Time.deltaTime));
                Vector3 newDirectionV3 = new Vector3(newDirection.x,0,newDirection.y);
                mechBody.velocity = commandPlat.TransformDirection(newDirectionV3);
                newDirectionV3Value = newDirectionV3;
            }
        

        


    }
    public void FuelConsumption()
    {
       float fuelMovement = newDirectionV3Value.magnitude;
       msh.fuelCount -= (fuelMovement * Time.deltaTime);
       if(outOfFuel)
       {
            firstCC = false;
            triggerCC = false;
            backsway = false;
            click1 = false; //could be a mistake
       }
    }
    public void armorChanges()
    {
        if(els.ejectThis == true & !doubleOnce)
        {
            maxSpeed *= 1.5f;
            doubleOnce = true;
        }
    }
    public void airborneCalculations()
    {
        if(airborne == true)
        {
            mechBody.useGravity = true;
            airborneReset = false;
        }
        if(airborne == false & spawning == true)
        {
            firstAirborne = true;
            airborneReset = true;
            mechBody.useGravity = false;
        }
    }
    public void rotateCalculations()
    {
       /* if(Mathf.Abs(m_RightRotatePress.axis.x) < deadzone & Mathf.Abs(m_RightRotatePress.axis.y) > deadzone)
        {  
            rotationSpeed = m_RightRotatePress.axis.y * rotateSens;
            rotationSpeed = rotationSpeed * Time.deltaTime;
            changeElevation += rotationSpeed; 
            clampedElevation = Mathf.Clamp(changeElevation,-upDownAngle,upDownAngle);
            if(changeElevation >= upDownAngle)
            {
                changeElevation = upDownAngle;
            }
            if(changeElevation <= -upDownAngle)
            {
                changeElevation = -upDownAngle;
            }
            rotateAroundThis2.localEulerAngles = new Vector3(-clampedElevation,rotateAroundThis2.localEulerAngles.y,rotateAroundThis2.localEulerAngles.z);

        }*/
        if(Mathf.Abs(m_RightRotatePress.axis.y) < deadzone | Mathf.Abs(m_RightRotatePress.axis.x) > deadzone)
        {   
            //rotationSpeed = m_RightRotatePress.axis.x * rotateSens;
           // rotationSpeed = rotationSpeed * Time.deltaTime;
            Vector3 mechAngularVelocity = mechBody.angularVelocity;
            Vector2 mechAngularVelocityV2 = new Vector2(mechAngularVelocity.x,mechAngularVelocity.z); //might be not x and z
            Vector2 newAngularVelocity = Vector2.Lerp(mechAngularVelocityV2,(new Vector2(m_RightRotatePress.axis.x,0) * maxRotation),(0.8f * Time.deltaTime));
            Vector3 newAngularVelocityV3 = new Vector3(newAngularVelocity.x,0,newAngularVelocity.y);
            transform.RotateAround(rotateAroundThis.position, Vector3.up, (m_RightRotatePress.axis.x * maxRotation)); 
            //mechBody.angularVelocity = newAngularVelocityV3;
            
            //VVVVVVVVVVVV    REFERENCE ONLY REFERENCE ONLY REFERENCE ONLY REFERENCE ONLY VVVVVVVVVVVVVVVVVVVVVVVVVVVVV
           /* Vector3 localMechDirection = commandPlat.InverseTransformDirection(mechBody.velocity);
            Vector2 mechDirectionV2 = new Vector2(localMechDirection.x,localMechDirection.z);
            Vector2 newDirection = Vector2.Lerp(mechDirectionV2,(m_MoveValue.axis * maxSpeed),(0.8f * Time.deltaTime));
            Vector3 newDirectionV3 = new Vector3(newDirection.x,0,newDirection.y);
            mechBody.velocity = commandPlat.TransformDirection(newDirectionV3);*/
        }  
    }
}
