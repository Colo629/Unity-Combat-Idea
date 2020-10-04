using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fingerColliderScript : MonoBehaviour
{
    public fingerGestureScript passG;
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
        if(other.CompareTag("indexF"))
        {
            Debug.Log("indexTrue");
            passG.indexF = true;
        }
        if(other.CompareTag("middleF"))
        {
            passG.middleF = true;
        }
        if(other.CompareTag("ringF"))
        {
            passG.ringF = true;
        }
        if(other.CompareTag("pinkyF"))
        {
            Debug.Log("pinkytrue");
           passG.pinkyF = true;
        }
    }
}
