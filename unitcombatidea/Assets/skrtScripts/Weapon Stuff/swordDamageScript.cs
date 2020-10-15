using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class swordDamageScript : MonoBehaviour
{
    public bool swordDamage1 = true;
    public damageScript damageScript;
    public Collider colliderHit;
    public Transform transformHit;
    public swordScript swordScript;
    public float slashPierce = 0;
    public float slashDamage = 0;
    public float stabDamage = 0;
    public float stabPierce = 0;
    public bool calculated;
    public moveOnly ms;
    public bool resetAttack;
    public ParticleSystem stabSparks;
    public bool slashDamage1;
    public bool stabDamage1;
    void OnTriggerEnter(Collider gumDumb)
    {
        if(swordScript.firing == true)
        {
            if(swordScript.slashAttack == true & !calculated)
            {
                calculateSlashDamage(gumDumb);
            }
            
        }
        if(swordScript.slashAttack == false & !calculated & ms.newDirectionV3Value.z >= 9.0f)
        {
            calculateStabDamage(gumDumb);
        }
    }
    void OnTriggerExit(Collider gumDumb)
    {
        slashDamage1 = false;
        stabDamage1 = false;
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
            }
        if(swordScript.slashAttack == false & ms.newDirectionV3Value.z >= 9.0f & !calculated)
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
        if(swordScript.slashAttack == false & swordScript.stabAttack == false & calculated == true)
        {
            StartCoroutine(attackCooldown());
        }
    }
       IEnumerator attackCooldown()
    {         
        calculated = true;
        yield return new WaitForSeconds(2);
        calculated = false;
        stabSparks.Stop(stabSparks);
    }
    public void calculateSlashDamage(Collider collisionData)
    {   
        damageScript = collisionData.gameObject.GetComponent<damageScript>();
        calculated = true;
        slashDamage1 = true;
    }
    
    public void calculateStabDamage(Collider collisionData)
    {
        stabSparks.Play();
        damageScript = collisionData.gameObject.GetComponent<damageScript>();
        FindObjectOfType<AudioManager>().Play("swordStabSound");
        calculated = true;
        stabDamage1 = true;
    }
}
