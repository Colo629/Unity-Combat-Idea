using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class switchWeapons : MonoBehaviour

{
public SteamVR_Input_Sources anyLeverSon;
public GameObject reference;
public GameObject hand;
public bool grabbed;
public SteamVR_Action_Boolean grabObject;
public Transform rotateRef;
public swordScript swordScript;
public swordScript bayonettScript;
public gunControlScript gcs;
public bool runItOnce;
    
  
  
  
  void OnTriggerStay(Collider other)
    {
        if(grabObject.GetStateDown(anyLeverSon))
        {
            grabbed = true;
            hand = other.gameObject;
        }
    }
 void Update()
    {
        if(grabObject.GetStateUp(anyLeverSon))
        {
            grabbed = false;
            hand = null;
        }
        if(grabbed)
        {
            Vector3 handPosition = transform.InverseTransformPoint(hand.transform.position).normalized;
            float leverAngle = Mathf.Atan2(handPosition.z,handPosition.y) * (360/(2 * Mathf.PI));
            rotateRef.localEulerAngles = new Vector3(Mathf.Clamp(leverAngle,-45,0),0,0);
            if(leverAngle < -44 & !runItOnce)
            {
                swordScript.gettingSpawned = true;
                swordScript.activateSword = true;
                bayonettScript.activateSword = false;
                gcs.destroyed = true;
                bayonettScript.gettingDespawned = true;
                runItOnce = true;
            }
            /*if(leverAngle >-33)
            {
                engineScript.engineOn = false;
            }*/
        }
    }
}
