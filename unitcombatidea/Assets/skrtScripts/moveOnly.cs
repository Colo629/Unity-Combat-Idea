using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class moveOnly : MonoBehaviour
{
    public SteamVR_Action_Vector2 m_MoveValue = null;
    public float maxSpeed;
    public float acceleration;
    public Rigidbody mechBody;
    public Transform commandPlat;
    public MeshCollider gumDumb;
    public leverScript leverLeft;
    public bool cruiseControl;
    public SteamVR_Action_Single leftMechTrigger;
    public bool triggerCC;
    public bool backsway;
    public bool firstGrab;
    public bool firstCC;
    public bool click1;

    // call rigidbody.velocity (vector3)
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
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
}
