using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class nightmareMove : MonoBehaviour
{
    public leverScript leverLeft; 
    public leverScript leverRight;
    public float m_Gravity = 40.0f;
    public float m_Sensititvity = 0.1f;
    public float m_MaxSpeed = 1.0f;
    public float m_RotateIncrement = 45;
    public float deadzone;
    public float rotateSens = 90f;
    public damageScript damageScriptL;
    public damageScript damageScriptR;

    public SteamVR_Action_Boolean m_LeftRotatePress = null;
    public SteamVR_Action_Vector2 m_RightRotatePress = null;
    public SteamVR_Action_Boolean m_MovePress = null;
    public SteamVR_Action_Vector2 m_MoveValue = null;

    private float m_Speed = 0.0f;
    private float rotationSpeed = 0.0f;

    private CharacterController m_CharacterController = null;
    private Transform m_CameraRig = null;
    public Transform platController = null;

    private void Awake()
    {
        m_CharacterController = GetComponent<CharacterController>();
    }
    // Start is called before the first frame update
    
    private void Start()
    {
      //  m_CameraRig = SteamVR_Render.Top().origin;

    }

    // Update is called once per frame
    private void Update()
    {
        HandleHeight();
       if(leverLeft.grabbed == true)
       { 
           CalculateMovement(); //set to only work when left stick grabbed
       }
       if(leverRight.grabbed == true)
       {
           Debug.Log("rightgrabbed");
        SnapRotation();    //set to only work when right stick is grabbed
       }
    }
    private void CalculateMovement()
    {
        //Figure out movement orientation
        Quaternion orientation = CalculateOrientation();
        Vector3 movement = Vector3.zero;

        //If not moving
        if(m_MoveValue.axis.magnitude == 0)
            m_Speed = 0;
            Debug.Log("not moving");
        
        if(m_MoveValue.axis.magnitude > deadzone)
            //Add, clamp
            m_Speed += m_MoveValue.axis.magnitude * m_Sensititvity;
            m_Speed = Mathf.Clamp(m_Speed,-m_MaxSpeed, m_MaxSpeed);

            //Orientation
            movement += orientation * (m_Speed * Vector3.forward)  ;
             Debug.Log("move it move it");

            //Gravity
             movement.y -= m_Gravity * Time.deltaTime;

        //Apply
        m_CharacterController.Move(movement * Time.deltaTime);
       
    }

    private void SnapRotation()
    {
        float snapValue = 0.0f;
   
       //  if (m_LeftRotatePress.GetStateDown(SteamVR_Input_Sources.RightHand))
        //snapValue = -Mathf.Abs(m_RotateIncrement);
    
        if (Mathf.Abs(m_RightRotatePress.axis.x)  < deadzone)
        {
            rotationSpeed = 0;
            Debug.Log("not turning");
        }
        if(Mathf.Abs(m_RightRotatePress.axis.x) > deadzone)
        {
            Debug.Log(m_RightRotatePress.axis.x);
            rotationSpeed = m_RightRotatePress.axis.x * rotateSens;
            rotationSpeed = rotationSpeed * Time.deltaTime * ((damageScriptL.healthPool + damageScriptR.healthPool)/400);

        //snapValue = Mathf.Abs(m_RotateIncrement);
        transform.RotateAround(platController.position, Vector3.up, rotationSpeed);   
        } 
    }
    
    private void HandleHeight()
    {
        //Get the head in local space
        float headHeight = Mathf.Clamp(platController.localPosition.y,0f, 4.5f);
        m_CharacterController.height = headHeight; 

        //Cut in half
        Vector3 newCenter = Vector3.zero;
        newCenter.y = (m_CharacterController.height / 2) - 2.8f;
        newCenter.y += m_CharacterController.skinWidth;

        // Move capsule in local space
        newCenter.x = platController.localPosition.x;
        newCenter.z = platController.localPosition.z;
        
        //rotate
        newCenter = Quaternion.Euler(0, -transform.eulerAngles.y, 0) * newCenter;

        //Apply
        m_CharacterController.center = newCenter;
    }
    private Quaternion CalculateOrientation()
    {
       float rotation = Mathf.Atan2(m_MoveValue.axis.x, m_MoveValue.axis.y);
       rotation *= Mathf.Rad2Deg;
       
        Vector3 orientationEuler = new Vector3(0, platController.eulerAngles.y + rotation,0);
       return Quaternion.Euler(orientationEuler);
    }
}

