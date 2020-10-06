using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

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
    public bool calculated;

    void OnTriggerEnter(Collider gumDumb)
    {
        if(swordScript.firing == true)
        {
            if(swordScript.slashAttack == true & !calculated)
            {
                calculateSlashDamage(gumDumb);
            }
            if(swordScript.stabAttack == true & !calculated)
            {
                calculateStabDamage(gumDumb);
            }
        }
    }
    void OnTriggerStay(Collider gumDumb)
    {
        if(!calculated)
        {
            if(swordScript.firing == true)
            {
                if(swordScript.slashAttack = true)
                {
                    calculateSlashDamage(gumDumb);
                }
                if(swordScript.stabAttack == true)
                {
                    calculateStabDamage(gumDumb);
                }
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
        if(swordScript.slashAttack == false & swordScript.stabAttack == false)
        {
            calculated = false;
        }
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
        calculated = true;
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
        calculated = true;
    }
}
