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
       Vector3 telePos = transform.TransformPoint(new Vector3(0f, 0f, 3)); 
       RaycastHit hit;
       if(Physics.Raycast(raycastTele.transform.position, raycastTele.transform.up, out hit, Mathf.Infinity))
       {
            Instantiate(raycastTele, telePos, Quaternion.Euler(-90,180,0));
            Debug.Log("summoned object");
        }
    }
    // Update is called once per frame
    void Update()
    {
            
    }
}
