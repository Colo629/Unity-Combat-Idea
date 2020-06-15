using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class leverScript : MonoBehaviour

{
  
    // Start is called before the first frame update
    public GameObject reference;
    public GameObject hand;
    public bool grabbed;
    public SteamVR_Action_Boolean grabObject;
    public Vector3 output;
    public SteamVR_Input_Sources rightLeverSon;
    public static float multiplier = 0.5f;
    public bool mirror;
    public bool armTriggerR;
    public bool armTriggerL;
    
    
    
    
    
    
    
    
    
    
    
    void OnTriggerStay(Collider other)
    {
        if(grabObject.GetStateDown(rightLeverSon))
        {
            grabbed = true;
            hand = other.gameObject;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(grabObject.GetStateUp(rightLeverSon))
        {
            grabbed = false;
            hand = null;
        }
        if(grabbed)
        {
            if(!mirror)
            {
            //rotate reference?
                armTriggerR = true;
                output = Vector3.ClampMagnitude(reference.transform.InverseTransformPoint(hand.transform.position),multiplier); //makes shit not able to rotate among other stuff
                output = new Vector3(0,Mathf.Clamp(output.y,-0.05f,multiplier/4),Mathf.Clamp(output.z,0,multiplier)); //Mathf.Clamp(output.x,-multiplier/2,0.25f
            if(hand.transform.localEulerAngles.z < 180)
                {
                output.x = (hand.transform.localEulerAngles.z - 93.7f)/210;
                }
            if(hand.transform.localEulerAngles.z > 180)
                {
                    output.x = ((hand.transform.localEulerAngles.z - 365) - 93.7f)/210;
                }
           // Debug.Log(hand.transform.localEulerAngles);
            output.x = Mathf.Clamp(output.x,-1,0.5f);
            transform.rotation = hand.transform.rotation;
            }

            if(mirror)
            {
                    armTriggerL = true;
                            //rotate reference?
                    output = Vector3.ClampMagnitude(reference.transform.InverseTransformPoint(hand.transform.position),multiplier); //makes shit not able to rotate among other stuff
                    output = new Vector3(0,Mathf.Clamp(output.y,-multiplier/4,0.05f),Mathf.Clamp(output.z,0,multiplier)); //Mathf.Clamp(output.x,-multiplier/2,0.25f
                if(hand.transform.localEulerAngles.z < 180)
                {
                    output.x = (hand.transform.localEulerAngles.z + 93.7f)/210;
                }
                    if(hand.transform.localEulerAngles.z > 180)
                {
                    output.x = ((hand.transform.localEulerAngles.z - 365) + 93.7f)/210;
                }
                // Debug.Log(hand.transform.localEulerAngles);
                output.x = Mathf.Clamp(output.x,-0.5f,1);
                transform.rotation = hand.transform.rotation;
            }
            
        }
        transform.position = reference.transform.TransformPoint(new Vector3(0,output.y,output.z)); //moves the aesthetics?
        
        // transform.localEulerAngles = new Vector3(output.x,transform.localEulerAngles.y,transform.localEulerAngles.z) ;
        //transform.localEulerAngles = output;
    }
}
