using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleTeleport : MonoBehaviour
{
    public GameObject raycastTele;
    public GameObject teleportThis;
    private AlchemyCircle alchCircle;
     bool shapeFlag = false;
     public GameObject destroyMe;
   
    void Start()
    {
        alchCircle = gameObject.GetComponent<AlchemyCircle>();
    }
    void OnTriggerStay(Collider other)
    {
        Debug.Log("staying");
         
         foreach(bool shape in alchCircle.simpleGeometryArray)
         {
            if (shape)
            {
                shapeFlag = true;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        
        if(shapeFlag == false)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
       Vector3 telePos = transform.TransformPoint(new Vector3(0f, 0f, 0)); 
       RaycastHit hit;
       if(Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
       {    
            Quaternion slopeRotation = Quaternion.FromToRotation(Vector3.forward, hit.normal);
            GameObject canvasClone = Instantiate(raycastTele, telePos, Quaternion.identity);
            canvasClone.transform.rotation = canvasClone.transform.rotation * slopeRotation;
           
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
