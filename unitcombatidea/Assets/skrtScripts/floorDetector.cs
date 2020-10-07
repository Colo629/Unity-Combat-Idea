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
                Debug.Log("grounded");
                moveScript.airborne = false;
            }
    }

    void OnTriggerStay(Collider other)
    {
            if(defineFoot.tag == "foot")
            {
                Debug.Log("grounded2");
                moveScript.airborne = false;
            }
           
    }
    void OnTriggerExit(Collider other)
    {
            if(defineFoot.tag == "foot")
            {
                Debug.Log("airborne");
                moveScript.airborne = true;
            }
    }

}
