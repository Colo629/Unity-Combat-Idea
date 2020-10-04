using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunScript : MonoBehaviour
{

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

    
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    public void fireGun()
    {         
        if(gcs.ammoPool > 0)
            {
                GameObject instBullet = Instantiate(bullet,transform.position,transform.rotation) as GameObject;
                Rigidbody instBulletRigidbody = instBullet.GetComponent<Rigidbody>();
                instBulletRigidbody.AddForce(instBullet.transform.forward * bulletSpeed);
                gcs.ammoPool -= 1f;
            }
    }
}