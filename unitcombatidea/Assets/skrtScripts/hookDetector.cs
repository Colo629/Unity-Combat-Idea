using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hookDetector : MonoBehaviour
{
    public GameObject defineHook;
    public GameObject player;
    public grapplingHook grapHookScriptL;
    public grapplingHook grapHookScriptR;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "hookable")
        {
            if(defineHook.tag == "hookR")
            {
            player.GetComponent<grapplingHook>().hookedR = true;
            player.GetComponent<grapplingHook>().hookedObjectR = other.gameObject;
            Debug.Log("rightHookHit");
            }
           
            if(defineHook.tag == "hookL")
            {
                Debug.Log("leftHookHit");
                player.GetComponent<grapplingHook>().hookedL = true;
                player.GetComponent<grapplingHook>().hookedObjectL = other.gameObject;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
    
    }
}
