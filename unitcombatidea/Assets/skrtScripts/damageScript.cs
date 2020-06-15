using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class damageScript : MonoBehaviour
{
    public float healthPool;
    public GameObject mechPart;
    public bool leftLeg;
    public bool rightLeg;
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
                    foreach (Transform child in transform)
                    {
                        Destroy(child.gameObject);
                    }
                    Destroy(mechPart);
                }
            }
        }
    }
}
