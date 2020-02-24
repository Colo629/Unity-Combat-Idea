using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class circleActivation : MonoBehaviour
{   
    public Renderer chalkGlow;
    private Material chalkMaterial;
    public bool hdr;
    //public ParticleSystem lightning;
    //public SteamVR_Controller.Device Controller;
    public bool fingerGesture = false;
   // public GameObject collidingCircle;
    public bool activateCircle;
    // Start is called before the first frame update
    void Start()
    {
        //lightning.Stop();
        chalkMaterial = chalkGlow.material;
    }
     void OnTriggerEnter(Collider other)
     {
         Debug.Log ("is colliding");
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
         hdr = true;
            chalkMaterial.SetColor("_EmissionColor", new Color(0.7393772f,2.103988f,2.488063f,1f) );
            Debug.Log("activate circle");
            
       // if (!lightning.isPlaying)
//{
           // lightning.Play();
            //hdr = true;
            //chalkMaterial.SetColor("_EmissionColor", new Color(1,1,1,2) );
            

        //} 
       
        
    }
}
