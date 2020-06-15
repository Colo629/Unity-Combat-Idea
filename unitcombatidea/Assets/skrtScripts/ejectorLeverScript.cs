using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ejectorLeverScript : MonoBehaviour
{

public SteamVR_Input_Sources rightLeverSon;
public GameObject reference;
public GameObject hand;
public bool grabbed;
public SteamVR_Action_Boolean grabObject;
public Transform rotateRef;
public partEjectorScript partEjector;
    
  
  
  
  void OnTriggerStay(Collider other)
    {
        if(grabObject.GetStateDown(rightLeverSon))
        {
            grabbed = true;
            hand = other.gameObject;
        }
    }
 void Update()
    {
        if(grabObject.GetStateUp(rightLeverSon))
        {
            grabbed = false;
            hand = null;
        }
        if(grabbed)
        {
            Vector3 handPosition = transform.InverseTransformPoint(hand.transform.position).normalized;
            float leverAngle = Mathf.Atan2(handPosition.z,handPosition.y) * (360/(2 * Mathf.PI));
            rotateRef.localEulerAngles = new Vector3(Mathf.Clamp(leverAngle,-45,0),0,0);
            if(leverAngle < -44)
            {
                Debug.Log("ka-boom");
                partEjector.leverPulled = true;
                
            }
        }
    }

}

    

