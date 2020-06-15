using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDamage : MonoBehaviour
{


    public damageScript damageScript;
    public Collider colliderHit;
    public Collision collisionData;
    public Transform transformHit;

    void OnCollisionEnter(Collision collisionData)
    {
        damageScript = collisionData.gameObject.GetComponent<damageScript>();
        damageScript.healthPool -= 20f;
       // Destroy(gameObject);
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
