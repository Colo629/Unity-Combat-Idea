using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDamage : MonoBehaviour
{

    public bool bulletDamage1 = true;
    public damageScript damageScript;
    public Collider colliderHit;
    public Collider collisionData;
    public Transform transformHit;
    public float bulletPierce = 0;
    public float bulletDam = 0;
    public Rigidbody thisBody;
    public Collider thisCollider;
    public Renderer thisRenderer;

    void OnTriggerEnter(Collider collisionData)
    {
       Destroy(thisBody);
       thisCollider.enabled = false;
       thisRenderer.enabled = false; 
       StartCoroutine(DestroyThis());
    }
    // Start is called before the first frame update
    public IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
