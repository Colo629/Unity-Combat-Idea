using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleTeleport : MonoBehaviour
{
    public GameObject raycastTele;
    public GameObject teleportThis;
    private AlchemyCircle alchCircle;
     bool shapeFlag = false;
     public GameObject canvasClone;
     public GameObject spawnedObject;
   
    void Start()
    {
        alchCircle = gameObject.GetComponent<AlchemyCircle>();
    }
    void OnTriggerStay(Collider other)
    {/*
        Debug.Log("staying" + other.transform.gameObject.name);
         
         foreach(bool shape in alchCircle.simpleGeometryArray)
         {
            if (shape)
            {
                shapeFlag = true;
            }
        }*/
    }
    
    void OnTriggerEnter(Collider other)
    {
       Vector3 telePos = transform.TransformPoint(new Vector3(0f, 0f, 0)); 
       RaycastHit hit;
       Debug.Log(other.transform.gameObject.name + "collider");
       if(Physics.Raycast(transform.position, transform.up, out hit, Mathf.Infinity))
       {    
            Quaternion slopeRotation = Quaternion.FromToRotation(Vector3.forward, hit.normal);
            canvasClone = Instantiate(raycastTele, hit.point, Quaternion.identity);
            canvasClone.transform.rotation = canvasClone.transform.rotation * slopeRotation;
            canvasClone.transform.position = canvasClone.transform.TransformPoint(new Vector3(0,0, 0.01f / 35));
           
           Debug.Log(hit.transform.gameObject.name);
           Debug.Log(hit.normal);
            Debug.Log("summoned object");
        }
    }
    // Update is called once per frame
    void Update()
    {
            
    }
}
