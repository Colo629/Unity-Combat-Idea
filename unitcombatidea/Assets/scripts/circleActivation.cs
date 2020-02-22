using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class circleActivation : MonoBehaviour
{
    public ParticleSystem lightning;
    //public SteamVR_Controller.Device Controller;
    public bool fingerGesture = false;
   // public GameObject collidingCircle;
    public bool activateCircle;
    // Start is called before the first frame update
    void Start()
    {
        lightning.Stop();
    }
     void OnTriggerEnter(Collider other)
     {
        if (fingerGesture == false) 
        {
            return;
        }
         else 
         {
            activateCircle = true;
         }
     }

    // Update is called once per frame
    void Update()
    {
        if (!activateCircle)
        {
            return;
        }
        if (!lightning.isPlaying)
        {
            lightning.Play();
        } 
       
        
    }
}
