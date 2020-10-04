using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class damageScript : MonoBehaviour
{
    public float healthPool;
    public GameObject mechPart;
    public bool leftLeg;
    public bool rightLeg;
    public float penValue = 0f;
    public bool damageTypeBullet = false;
    public bool damageTypeSword = false;
    public bool destroyed;
    public GameObject trueKill;
    public GameObject mechPart2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!leftLeg)
        {
            if(!rightLeg)
            {
                if(healthPool <= 20f)
                {
                    if(!destroyed)
                    {
                        foreach (Transform child in transform)
                        {
                            Destroy(child.gameObject);
                        }
                        Destroy(mechPart);
                        Destroy(trueKill);
                        
                        
                        if(damageTypeSword == true)
                        {
                            GameObject instDestroyedPart = Instantiate(mechPart,transform.position,transform.rotation) as GameObject;
                            //ejectedPart.GetComponent<Rigidbody>()
                            Rigidbody instDestroyedRigidbody = instDestroyedPart.GetComponent<Rigidbody>();
                            instDestroyedRigidbody.isKinematic = false;
            
                            
                        }
                        if(damageTypeBullet == true)
                        {
                            GameObject instDestroyedPart = Instantiate(mechPart,transform.position,transform.rotation) as GameObject;
                            //ejectedPart.GetComponent<Rigidbody>()
                            Rigidbody instDestroyedRigidbody = instDestroyedPart.GetComponent<Rigidbody>();
                            instDestroyedRigidbody.isKinematic = false;
   
                        }
                        destroyed = true;
                    }
                }
            }
        }
    }
}
