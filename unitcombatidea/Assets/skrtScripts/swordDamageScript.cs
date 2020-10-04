using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordDamageScript : MonoBehaviour
{
    public damageScript damageScript;
    public Collider colliderHit;
    public Transform transformHit;
    public swordScript swordScript;
    public float slashPierce = 0;
    public float slashDamage = 0;
    public float stabDamage = 0;
    public float stabPierce = 0;

    void OnTriggerEnter(Collider gumDumb)
    {
        
        if(swordScript.firing == true)
        {
            if(!swordScript.stabSwitch)
            {
                calculateSlashDamage(gumDumb);
            }
            if(swordScript.stabSwitch)
            {
                calculateStabDamage(gumDumb);
            }
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

    public void calculateSlashDamage(Collider collisionData)
    {   
        
        damageScript = collisionData.gameObject.GetComponent<damageScript>();
        if(slashPierce >= damageScript.penValue)
        {
            
            damageScript.healthPool -= slashDamage;
        }
        if(slashPierce < damageScript.penValue)
        {
            
            damageScript.healthPool -= (slashDamage/5);
        }
    }
    
    public void calculateStabDamage(Collider collisionData)
    {
       
        damageScript = collisionData.gameObject.GetComponent<damageScript>();
        if(stabPierce >= damageScript.penValue)
        {
            
            damageScript.healthPool -= stabDamage;
        }
        if(stabPierce < damageScript.penValue)
        {
            damageScript.healthPool -= (stabDamage/5);
        }
    }
}
