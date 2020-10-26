using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class moveOnly : MonoBehaviour
{
    public float rotAcc;
    public float rotDec;
    public MechStatusHolder msh;
    public SteamVR_Action_Vector2 m_MoveValue = null;
    public float maxSpeed;
    public float maxRotation;
    public float acceleration2;
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
    private float privateRotate;
    private Rigidbody mechRigidbody;
    private bool decelerating;

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
            //FuelConsumption();
        }
        if(spawning)
        {
            mechBody.useGravity = false;
        }
        armorChanges();
        if(leverRight.grabbed == true)
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
                MovementCalculations();
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
                 
            if(triggerCC == true & !firstCC & !airborne & !outOfFuel)
            {
                MovementCalculations();
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
            MovementCalculations();
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
        {    //rotateSense
              
            if(m_RightRotatePress.axis.x == 0)
            {
                privateRotate = ((m_RightRotatePress.axis.x * rotDec) + privateRotate) / (rotDec + 1f);
            } 
            else
            {
                privateRotate = ((m_RightRotatePress.axis.x * rotAcc) + privateRotate) / (rotAcc + 1f);
            }       
            transform.RotateAround(rotateAroundThis.position, Vector3.up, (privateRotate * maxRotation));      
        }  
    }
    public void MovementCalculations()
    {
        /*Vector3 localMechDirection = commandPlat.InverseTransformDirection(mechBody.velocity);
        Vector2 mechDirectionV2 = new Vector2(localMechDirection.x,localMechDirection.z);
        Vector2 newDirection = Vector2.Lerp(mechDirectionV2,(m_MoveValue.axis * 25f),(0.8f * Time.deltaTime)); //movevalue.axis used to be multipliedd by maxspeed
        Vector3 newDirectionV3 = new Vector3(newDirection.x,0,newDirection.y);
        mechBody.velocity = commandPlat.TransformDirection(newDirectionV3);
        newDirectionV3Value = newDirectionV3;*/
        Vector3 localMechDirection = commandPlat.InverseTransformDirection(mechBody.velocity);
        Vector2 mechDirectionV2 = new Vector2(localMechDirection.x,localMechDirection.z);
        Vector2 newDirection = new Vector2(m_MoveValue.axis.x * acceleration2, m_MoveValue.axis.y * acceleration2);
        Vector3 newDirectionV3 = new Vector3(newDirection.x,0,newDirection.y);
        Vector3 finalDirectionV3 = commandPlat.TransformDirection(newDirectionV3);
        mechBody.AddForce(finalDirectionV3 , ForceMode.Impulse);    //modify
        mechBody.velocity = Vector3.ClampMagnitude(mechBody.velocity, maxSpeed);
        newDirectionV3Value = mechBody.velocity;
        Debug.Log(mechBody.velocity.magnitude);
    }
}
