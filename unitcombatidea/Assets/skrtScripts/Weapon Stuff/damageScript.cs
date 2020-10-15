using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class damageScript : MonoBehaviour
{
    public bulletDamage bulletDamage;
    public swordDamageScript swordDamage;
    public GameObject mechPart;
    public bool leftLeg;
    public bool rightLeg;
    public bool rightArm;
    public bool leftArm;
    public bool lla;
    public bool laa;
    public bool rla;
    public bool raa;
    public float penValue = 0f;
    public bool damageTypeBullet = false;
    public bool damageTypeSword = false;
    public bool destroyed;
    public EnemyManager em;
    public bool head;
    public bool torso;
    public bool gun;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnTriggerEnter(Collider collisionData)
    {
        if(collisionData.tag == "bullet")
        {
            bulletDamage = collisionData.gameObject.GetComponent<bulletDamage>();
            bulletDamageCalc();
        }
        if(collisionData.tag == "sword")
        {
            swordDamage = collisionData.gameObject.GetComponent<swordDamageScript>();
            if(swordDamage.stabDamage1)
            {
                stabDamageCalc();
            }
            if(swordDamage.slashDamage1)
            {
                slashDamageCalc();
            }
        } 
    }
    public void OnTriggerExit(Collider CollisionData)
    {
        bulletDamage = null;
        swordDamage = null;
    }
    // Update is called once per frame
    public void bulletDamageCalc()
    {
        if(lla)
        {
            em.leftLegArmorCount -= bulletDamage.bulletDam;
        }
        if(rla)
        {
            em.rightLegArmorCount -= bulletDamage.bulletDam;
        }
        if(laa)
        {
            em.leftArmArmorCount -= bulletDamage.bulletDam;
        }
        if(raa)
        {
            em.rightArmArmorCount -= bulletDamage.bulletDam;
        }
        if(leftLeg)
        {
            em.leftLegHp -= bulletDamage.bulletDam;
        }
        if(rightLeg)
        {
            em.rightLegHp -= bulletDamage.bulletDam;
        }
        if(leftArm)
        {
            em.leftArmHp -= bulletDamage.bulletDam;
        }
        if(rightArm)
        {
            em.rightArmHp -= bulletDamage.bulletDam;
        }
        if(head)
        {
            em.headHp -= bulletDamage.bulletDam;
        }
        if(torso)
        {
            em.torsoHp -= bulletDamage.bulletDam;
        }
        if(gun)
        {
            em.gunHp -= bulletDamage.bulletDam;
        }
    }
    public void stabDamageCalc()
    {
        if(lla)
        {
            em.leftLegArmorCount -= swordDamage.stabDamage;
        }
        if(rla)
        {
            em.rightLegArmorCount -= swordDamage.stabDamage;
        }
        if(laa)
        {
            em.leftArmArmorCount -= swordDamage.stabDamage;
        }
        if(raa)
        {
            em.rightArmArmorCount -= swordDamage.stabDamage;
        }
        if(leftLeg)
        {
            em.leftLegHp -= swordDamage.stabDamage;
        }
        if(rightLeg)
        {
            em.rightLegHp -= swordDamage.stabDamage;
        }
        if(leftArm)
        {
            em.leftArmHp -= swordDamage.stabDamage;
        }
        if(rightArm)
        {
            em.rightArmHp -= swordDamage.stabDamage;
        }
        if(head)
        {
            em.headHp -= swordDamage.stabDamage;
        }
        if(torso)
        {
            em.torsoHp -= swordDamage.stabDamage;
        }
        if(gun)
        {
            em.gunHp -= swordDamage.stabDamage;
        }
    }
    public void slashDamageCalc()
    {
        if(lla)
        {
            em.leftLegArmorCount -= swordDamage.slashDamage;
        }
        if(rla)
        {
            em.rightLegArmorCount -= swordDamage.slashDamage;
        }
        if(laa)
        {
            em.leftArmArmorCount -= swordDamage.slashDamage;
        }
        if(raa)
        {
            em.rightArmArmorCount -= swordDamage.slashDamage;
        }
        if(leftLeg)
        {
            em.leftLegHp -= swordDamage.slashDamage;
        }
        if(rightLeg)
        {
            em.rightLegHp -= swordDamage.slashDamage;
        }
        if(leftArm)
        {
            em.leftArmHp -= swordDamage.slashDamage;
        }
        if(rightArm)
        {
            em.rightArmHp -= swordDamage.slashDamage;
        }
        if(head)
        {
            em.headHp -= swordDamage.slashDamage;
        }
        if(torso)
        {
            em.torsoHp -= swordDamage.slashDamage;
        }
        if(gun)
        {
            em.gunHp -= swordDamage.slashDamage;
        }
    }
    void Update()
    {
                //if(healthPool <= 20f)
                /*{
                    if(!destroyed)
                    {
                        foreach (Transform child in mechPart.transform)
                        {
                            Destroy(child.gameObject);
                        }
                        Destroy(mechPart);
                        
                        
                        
                        if(damageTypeSword == true)
                        {
                            GameObject instDestroyedPart = Instantiate(mechPart,transform.position,transform.rotation) as GameObject;
                            //ejectedPart.GetComponent<Rigidbody>()
                            Rigidbody instDestroyedRigidbody = instDestroyedPart.GetComponent<Rigidbody>();
                            instDestroyedRigidbody.isKinematic = false;
            
                            
                        }
                        if(damageTypeBullet == true)
                        {
                            GameObject instDestroyedPart = Instantiate(mechPart,transform.position,transform.rotation) as GameObject;
                            //ejectedPart.GetComponent<Rigidbody>()
                            Rigidbody instDestroyedRigidbody = instDestroyedPart.GetComponent<Rigidbody>();
                            instDestroyedRigidbody.isKinematic = false;
   
                        }
                        destroyed = true;
                    }
                }*/
            }
        } 
