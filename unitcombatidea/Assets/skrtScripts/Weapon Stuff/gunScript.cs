using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunScript : MonoBehaviour
{

public bool one = true;
            public bool two;
            public bool three;
            public bool four;
            public bool five;
    // Start is called before the first frame update
    public armScript rightArm;
    public armScript leftArm;
    public damageScript damageScript;
    public gunControlScript gcs;
    public GameObject bullet;
    public float bulletSpeed = 1000f;
    public bool pistolFiredR = false;
    public bool pistolFiredL = false;
    public float bulletsFired = 0;
    public float bulletPierce = 0;
    public MechStatusHolder msh;
    public float dispersionValue;
    public float pellets;

    
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    public void fireGun()
    {         
        if(msh.ammoCount > 0 & msh.pump == false)
            {
                Quaternion aimVector = Quaternion.RotateTowards(transform.rotation,Random.rotation,dispersionValue);
                GameObject instBullet = Instantiate(bullet,transform.position,aimVector) as GameObject;
                Rigidbody instBulletRigidbody = instBullet.GetComponent<Rigidbody>();
                instBulletRigidbody.AddForce(instBullet.transform.forward * bulletSpeed);
                msh.ammoCount -= 1f;
                Quaternion aimVector1 = Quaternion.RotateTowards(transform.rotation,Random.rotation,dispersionValue);
                GameObject instBullet1 = Instantiate(bullet,transform.position,aimVector1) as GameObject;
                Rigidbody instBulletRigidbody1 = instBullet1.GetComponent<Rigidbody>();
                instBulletRigidbody1.AddForce(instBullet1.transform.forward * bulletSpeed);
                msh.ammoCount -= 1f;
            }
        if(msh.ammoCount > 0 & msh.pump == true)
        {
            for(int i = 0; i < pellets ; i++)
            {
                Quaternion aimVector = Quaternion.RotateTowards(transform.rotation,Random.rotation,dispersionValue);
                GameObject instBullet = Instantiate(bullet,transform.position,aimVector) as GameObject;
                Rigidbody instBulletRigidbody = instBullet.GetComponent<Rigidbody>();
                instBulletRigidbody.AddForce(instBullet.transform.forward * bulletSpeed); 
            }
            msh.ammoCount -= 1f; 
        }
    }
}