using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class partEjectorLeverless : MonoBehaviour
{

    public GameObject ejectedPart;
    public bool leverPulled = false;
    public leverLessEjection leverLessEjection;
    public bool ejected;
    public float pushSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!ejected)
        {
            if(leverLessEjection.ejectThis == true)
            {
                ejected = true;
                foreach(Transform child in transform)
                {
                    Destroy(child.gameObject);
                }
                Destroy(ejectedPart);
                GameObject instEjectedPart = Instantiate(ejectedPart,transform.position,transform.rotation) as GameObject;
                //ejectedPart.GetComponent<Rigidbody>()
                Rigidbody instEjectedRigidbody = instEjectedPart.GetComponent<Rigidbody>();
                instEjectedRigidbody.isKinematic = false;
                instEjectedRigidbody.AddForce(instEjectedPart.transform.forward * pushSpeed);           
            }
        }

    }  
}
