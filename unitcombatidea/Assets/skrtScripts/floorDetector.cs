using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class floorDetector : MonoBehaviour
{
    public GameObject defineFoot;
    public moveOnly moveScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        
            if(defineFoot.tag == "foot")
            {
                moveScript.airborne = false;
                moveScript.spawning = true;
            }
    }
    void OnTriggerStay(Collider other)
    {
        moveScript.airborne = false;
        moveScript.spawning = true;
    }
    void OnTriggerExit(Collider other)
    {
            if(defineFoot.tag == "foot")
            {
                moveScript.airborne = true;
                moveScript.spawning = true;
            }
    }

}
