using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class circleActivation : MonoBehaviour
{   
    public bool firstCollision = false;
    public bool gestureSword = false;
    public bool gestureSpear = false;
    public bool gestureWall = false;
    public GameObject sword;
    public GameObject spear;
    public GameObject wall;
    private AlchemyCircle alchCircle;
    public Renderer chalkGlow;
    private Material chalkMaterial;
    public bool hdr;
    //public ParticleSystem lightning;
    public bool fingerGesture = false;
   // public GameObject collidingCircle;
    public bool activateCircle;
    public bool firstActivation = false;
    // Start is called before the first frame update
    void Start()
    {
        alchCircle = gameObject.GetComponent<AlchemyCircle>();
        //lightning.Stop();
        chalkMaterial = chalkGlow.material;
    }
     void OnTriggerEnter(Collider other) 
     {
        bool shapeFlag = false;
        Debug.Log ("is colliding");
         
         foreach(bool shape in alchCircle.simpleGeometryArray)
         {
            if (shape)
            {
                shapeFlag = true;
            }
         }
        if (fingerGesture == false) 
        {
            return;
        }
        if (shapeFlag == false)
        {
            return;
        }
          if(firstCollision == false)
         {
             firstCollision = true;
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
        chalkMaterial.SetColor("_EmissionColor", new Color(0.7393772f,2.103988f,2.488063f,1f) );
            Debug.Log("circle activation");
            hdr = true;
        if (!firstActivation == true)
        {
            if(gestureSword ==true)
            {

            
            Vector3 swordPos = transform.TransformPoint(new Vector3(0f, 0f, -20f));
            GameObject swordGameObject = Instantiate(sword, swordPos, transform.rotation);  
            swordGameObject.transform.rotation = transform.rotation; 
            Debug.Log("summon sword");
            firstActivation = true;
            }
        
        
            if(gestureSpear == true)
            {

            
            Vector3 spearPos = transform.TransformPoint(new Vector3(0,0,-30f));
            GameObject spearGameObject = Instantiate(spear, spearPos, transform.rotation);
            spearGameObject.transform.rotation = transform.rotation;
            Debug.Log("summon spear");
            firstActivation = true;
            }
            return;
        }
                        
        
            
            
       // if (!lightning.isPlaying)
//{
           // lightning.Play();
            //hdr = true;
            //chalkMaterial.SetColor("_EmissionColor", new Color(1,1,1,2) );
            

        //} 
       
        
    }
}
