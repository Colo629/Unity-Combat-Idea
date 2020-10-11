using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDamage : MonoBehaviour
{

    public damageScript damageScript;
    public Collider colliderHit;
    public Collider collisionData;
    public Transform transformHit;
    public float bulletPierce = 0;
    public float bulletDam = 0;

    void OnTriggerEnter(Collider collisionData)
    {
        damageScript = collisionData.gameObject.GetComponent<damageScript>();
        if(bulletPierce >= damageScript.penValue)
        {
            damageScript.healthPool -= bulletDam;
            damageScript.damageTypeBullet = true;
            damageScript.damageTypeSword = false;
       // Destroy(gameObject);
        }
        if(bulletPierce < damageScript.penValue)
        {
            damageScript.healthPool -= bulletDam/5;
            damageScript.damageTypeBullet = true;
            damageScript.damageTypeSword = false;
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
