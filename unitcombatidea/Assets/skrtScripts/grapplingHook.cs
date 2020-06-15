using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class grapplingHook : MonoBehaviour
{
    public GameObject hookR;
    public GameObject hookL;
    public GameObject hookHolderR;
    public GameObject hookHolderL;


    public float hookTravelSpeed;
    public float playerTravelSpeed;

    public bool hookedL;
    public bool hookedR;
    public GameObject hookedObjectL;
    public GameObject hookedObjectR;
    public bool firedR;
    public bool firedL;
    public SteamVR_Action_Boolean fireRightGrapple;
    public SteamVR_Action_Boolean fireLeftGrapple;
    public SteamVR_Action_Boolean retractRightGrapple;
    public SteamVR_Action_Boolean retractLeftGrapple;
    public SteamVR_Input_Sources rightHand;
    public SteamVR_Input_Sources leftHand;
    private bool grounded;
    public bool mirror;

    public float maxDistance;
    private float currentDistanceR;
    private float currentDistanceL;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //firing the hook
        
        if(fireRightGrapple.GetStateDown(rightHand) == true)
        {
            if(firedR == false)
            { //replace the trigger with VR trigger
                firedR = true;
            }
        }
        if(firedR == true & hookedR == false)
        {
            hookR.transform.Translate(Vector3.forward * Time.deltaTime * hookTravelSpeed);//hook speed
            currentDistanceR = Vector3.Distance(transform.position,hookR.transform.position); //calculate distance between these two

            if(currentDistanceR >= maxDistance)
            {
                ReturnHookR();
            }

        }
        if(hookedR == true & firedR == true  )
        {
            Debug.Log("returnhookL + rightHookHit");
            ReturnHookL();
            hookR.transform.parent = hookedObjectR.transform;
            transform.position = Vector3.MoveTowards(transform.position, hookR.transform.position, Time.deltaTime * playerTravelSpeed);
            float distanceToHookR = Vector3.Distance(transform.position, hookR.transform.position); //caluclating distance between this distance object to hook

            
            if(retractRightGrapple.GetStateDown(rightHand) == true) //change this to when player firese anotherhook or cancels hook
            {
                ReturnHookR();
                Debug.Log("returnhook");
            }
        }
        
        if(fireLeftGrapple.GetStateDown(leftHand) == true)
        {
            if(firedL == false)
            { //replace the trigger with VR trigger
                firedL = true;
            }
        }
        if(firedL == true & hookedL == false)
        {
            hookL.transform.Translate(Vector3.forward * Time.deltaTime * hookTravelSpeed);//hook speed
            currentDistanceL = Vector3.Distance(transform.position,hookL.transform.position); //calculate distance between these two

            if(currentDistanceL >= maxDistance)
            {
                ReturnHookL();
            }

        }
        if(hookedL == true & firedL == true  )
        {
            Debug.Log("ReturnRightHook + lefthookhit");
            ReturnHookR();
            hookL.transform.parent = hookedObjectL.transform;
            transform.position = Vector3.MoveTowards(transform.position, hookL.transform.position, Time.deltaTime * playerTravelSpeed);
            float distanceToHookL = Vector3.Distance(transform.position, hookL.transform.position); //caluclating distance between this distance object to hook

            if(retractLeftGrapple.GetStateDown(leftHand) == true) //change this to when player firese anotherhook or cancels hook
            {
                ReturnHookL();
                Debug.Log("returnhook");
            }
            if(retractLeftGrapple.GetStateDown(leftHand) == true)
            {
                ReturnHookL();
            }
            /*else
            {
                hookL.transform.parent = hookHolderL.transform;
            }*/
        }
        
    }

    void ReturnHookL()
    {
        hookL.transform.parent = hookHolderL.transform;
        hookL.transform.rotation = hookHolderL.transform.rotation;
        hookL.transform.position = hookHolderL.transform.position;
        firedL = false;
        hookedL = false;
    }
    void ReturnHookR()
    {
        hookR.transform.parent = hookHolderR.transform;
        hookR.transform.rotation = hookHolderR.transform.rotation;
        hookR.transform.position = hookHolderR.transform.position;
        firedR = false;
        hookedR = false;
    }
}
