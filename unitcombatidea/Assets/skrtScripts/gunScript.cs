using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunScript : MonoBehaviour
{

    // Start is called before the first frame update
    public armScript rightArm;
    public armScript leftArm;
    public damageScript damageScript;
    public GameObject bullet;
    public float bulletSpeed = 1000f;
    public bool pistolFiredR = false;
    public bool pistolFiredL = false;

    
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(!pistolFiredR)
        {
             if(rightArm.fireRightGun == true)
        {
                GameObject instBullet = Instantiate(bullet,transform.position,transform.rotation) as GameObject;
                Rigidbody instBulletRigidbody = instBullet.GetComponent<Rigidbody>();
                instBulletRigidbody.AddForce(instBullet.transform.forward * bulletSpeed);
                pistolFiredR = true;
            //deleting bullets after a while might be a good idea
            
        }
        //}
        }
         if(!pistolFiredL)
        {
             if(leftArm.fireLeftGun == true)
        {
                GameObject instBullet = Instantiate(bullet,transform.position,transform.rotation) as GameObject;
                Rigidbody instBulletRigidbody = instBullet.GetComponent<Rigidbody>();
                instBulletRigidbody.AddForce(instBullet.transform.forward * bulletSpeed);
                pistolFiredL = true;
            //deleting bullets after a while might be a good idea
            
        }
    }

    }
    }
