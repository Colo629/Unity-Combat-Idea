﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class circleActivation : MonoBehaviour
{   private float currentTime = 0;
    public bool timeActivate = false;
    public bool firstCollision = false;
    public bool gestureSword = false;
    public bool gestureSpear = false;
    public bool gestureWall = false;
    public bool gestureSwordAttack = false;
    public bool gestureGroundSpikes = false;
    public bool gestureSpearAttack = false;
    public GameObject sword;
    public GameObject spear;
    public GameObject wall;
    public GameObject swordAttack;
    public GameObject groundSpikes;
    public GameObject spearAttack;
    private AlchemyCircle alchCircle;
    public Renderer chalkGlow;
    private Material chalkMaterial;
    public bool hdr;
    public ParticleSystem lightning;
    public bool fingerGesture = false;
   // public GameObject collidingCircle;
    public bool activateCircle;
    public bool firstActivation = false;
    public GameObject spawnedObject;
    float timer = 0f;
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
                
        if (!firstActivation == true)
        {
            if(gestureSword ==true)
            {

            
            Vector3 swordPos = transform.TransformPoint(new Vector3(0f, 0f, -0.1f/14.5f));
            GameObject swordGameObject = Instantiate(sword, swordPos, transform.rotation);  
            swordGameObject.transform.rotation = transform.rotation; 
            Debug.Log("summon sword");
            firstActivation = true;
            }
        
        
            if(gestureSpear == true)
            {

            
            Vector3 spearPos = transform.TransformPoint(new Vector3(0,0,-0.70f/14.5f));
            GameObject spearGameObject = Instantiate(spear, spearPos, transform.rotation);
            spearGameObject.transform.rotation = transform.rotation;
            Debug.Log("summon spear");
            firstActivation = true;
            }
            
            if(gestureWall ==true)
            {
                Vector3 wallPos = transform.TransformPoint(new Vector3(0,0,-0.85f/14.5f));
                GameObject wallGameObject = Instantiate(wall, wallPos, transform.rotation);
                wallGameObject.transform.rotation = transform.rotation;
                Debug.Log("summon wall");
                firstActivation = true;
            }
            if(gestureSwordAttack == true)
            {
            Vector3 swordAttackPos = transform.TransformPoint(new Vector3(170,0,0/14.5f));
            GameObject swordAttackGameObject = Instantiate(swordAttack, swordAttackPos, transform.rotation);
            swordAttackGameObject.transform.rotation = Quaternion.Euler(170,0,0);
            Debug.Log("summon sword attack");
            firstActivation = true;
            }
            if(gestureSpearAttack == true)
            {
            Vector3 spearAttackPos = transform.TransformPoint(new Vector3(0,0,0/14.5f)); 
            GameObject spearAttackGameObject = Instantiate(spearAttack, spearAttackPos, transform.rotation);
            spearAttackGameObject.transform.rotation = Quaternion.Euler(170,0,0);
            Debug.Log("summon spear attack");
            firstActivation = true;
            }
            if(gestureGroundSpikes ==true)
            {
                Vector3 groundSpikesPos = transform.TransformPoint(new Vector3(0,0,-0.85f/14.5f));
                GameObject groundSpikesGameObject = Instantiate(groundSpikes, groundSpikesPos, transform.rotation);
                groundSpikesGameObject.transform.rotation = transform.rotation;
                Debug.Log("summon ground spikes");
                firstActivation = true;
            }
        }
       if(!timeActivate == true)
            {
               currentTime = Time.time;
               timeActivate = true;
            }
            if(Time.time - currentTime <= 5)
            {
                
                 chalkMaterial.SetColor("_EmissionColor", new Color(0.7393772f,2.103988f,2.488063f,1f));
                 Debug.Log("circle activation");
                 hdr = true;
                 lightning.Play();
                
            }
            else
            {
                Destroy(gameObject);
                lightning.Stop();
                chalkMaterial.SetColor("_EmissionColor", new Color(0,0,0,0));
                hdr = false;
            }       
            return;
        
    }
}
