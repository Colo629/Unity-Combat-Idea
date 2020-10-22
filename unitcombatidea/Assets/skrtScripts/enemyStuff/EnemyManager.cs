using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    public AudioSource engineNoise;
    public EnemyDeathCounter edc;
    public Transform headHoncho;
    public Rigidbody headHonchoR;
    public bool armored;
    public float leftArmHp;
    public float rightArmHp;
    public float leftLegHp;
    public float rightLegHp;
    public float rightArmArmorCount;
    public float leftArmArmorCount;
    public float rightLegArmorCount;
    public float leftLegArmorCount;
    public float torsoHp;
    public float headHp;
    public float gunHp;
    public Transform leftLegFloat;
    public Transform rightLegFloat;
    public Transform gun;
    public Transform leftArm;
    public Transform rightArm;
    public Transform leftLeg;
    public Transform rightLeg;
    public Transform leftArmArmor;
    public Transform rightArmArmor;
    public Transform leftLegArmor;
    public Transform rightLegArmor;
    public Transform dropGun;
    public float ejectSpeed;
    public bool boss;
    public bool runOnce = false;
    public bool runOnce1 = false;
    public bool runOnce2 = false;
    public bool runOnce3 = false;
    public bool runOnce4 = false;
    public bool runOnce5 = false;
    public bool runOnce6 = false;
    public bool runOnce7;
    public bool runOnce8;
    public bool runOnce9;
    public bool runOnce10;
    // Start is called before the first frame update
    void Start()
    {
        if(!armored)
        {
            leftArmArmor = null;
            rightArmArmor = null;
            leftLegArmor = null;
            rightLegArmor = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(armored)
        {
            if(leftArmArmorCount <= 0)
            {
                if(!runOnce7)
                {
                    GameObject ejectLarm = Instantiate(leftArmArmor.gameObject, leftArmArmor.position,leftArmArmor.rotation);
                    leftArmArmor.gameObject.SetActive(false);
                    Rigidbody ejectLarmB = ejectLarm.GetComponent<Rigidbody>();
                    ejectLarmB.isKinematic = false;
                    ejectLarmB.AddForce(ejectLarm.transform.forward * ejectSpeed);
                    runOnce7 = true; 
                }
                

            }
            if(rightArmArmorCount <= 0)
            {
                if(!runOnce8)
                {
                    GameObject ejectLarm = Instantiate(rightArmArmor.gameObject, rightArmArmor.position,rightArmArmor.rotation);
                    rightArmArmor.gameObject.SetActive(false);
                    Rigidbody ejectLarmB = ejectLarm.GetComponent<Rigidbody>();
                    ejectLarmB.isKinematic = false;
                    ejectLarmB.AddForce(ejectLarm.transform.forward * ejectSpeed);
                    runOnce8 = true; 
                }
            }
            if(rightLegArmorCount <= 0)
            {
                if(!runOnce9)
                {
                    GameObject ejectLarm = Instantiate(rightLegArmor.gameObject, rightLegArmor.position,rightLegArmor.rotation);
                    rightLegArmor.gameObject.SetActive(false);
                    Rigidbody ejectLarmB = ejectLarm.GetComponent<Rigidbody>();
                    ejectLarmB.isKinematic = false;
                    ejectLarmB.AddForce(ejectLarm.transform.forward * ejectSpeed);
                    runOnce9 = true; 
                }
            }
            if(leftLegArmorCount <= 0)
            {
                if(!runOnce10)
                {
                    GameObject ejectLarm = Instantiate(leftLegArmor.gameObject, leftLegArmor.position,leftLegArmor.rotation);
                    leftLegArmor.gameObject.SetActive(false);
                    Rigidbody ejectLarmB = ejectLarm.GetComponent<Rigidbody>();
                    ejectLarmB.isKinematic = false;
                    ejectLarmB.AddForce(ejectLarm.transform.forward * ejectSpeed);
                    runOnce10 = true; 
                }
            }
        }
         
        /////////////////////////////////////
        if(leftArmHp <= 0)
        {
            if(!runOnce1)
            {
                GameObject ejectLarm = Instantiate(leftArm.gameObject, leftArm.position,leftArm.rotation);
                leftArm.gameObject.SetActive(false);
                Rigidbody ejectLarmB = ejectLarm.GetComponent<Rigidbody>();
                ejectLarmB.isKinematic = false;
                ejectLarmB.AddForce(ejectLarm.transform.forward * ejectSpeed);
                runOnce1 = true; 
            }
            

        }
        if(rightArmHp <= 0)
        {
             if(!runOnce2)
            {
                GameObject ejectLarm = Instantiate(rightArm.gameObject, rightArm.position,rightArm.rotation);
                rightArm.gameObject.SetActive(false);
                Rigidbody ejectLarmB = ejectLarm.GetComponent<Rigidbody>();
                ejectLarmB.isKinematic = false;
                ejectLarmB.AddForce(ejectLarm.transform.forward * ejectSpeed);
                runOnce2 = true; 
            }
        }
        if(rightLegHp <= 0)
        {
             if(!runOnce3)
            {
                GameObject ejectLarm = Instantiate(rightLeg.gameObject, rightLeg.position,rightLeg.rotation);
                rightLeg.gameObject.SetActive(false);
                Rigidbody ejectLarmB = ejectLarm.GetComponent<Rigidbody>();
                ejectLarmB.isKinematic = false;
                ejectLarmB.AddForce(ejectLarm.transform.forward * ejectSpeed);
                rightLegFloat.gameObject.SetActive(false);
                runOnce3 = true; 
            }
        }
        if(leftLegHp <= 0)
        {
            if(!runOnce4)
            {
                GameObject ejectLarm = Instantiate(leftLeg.gameObject, leftLeg.position,leftLeg.rotation);
                leftLeg.gameObject.SetActive(false);
                Rigidbody ejectLarmB = ejectLarm.GetComponent<Rigidbody>();
                ejectLarmB.isKinematic = false;
                ejectLarmB.AddForce(ejectLarm.transform.forward * ejectSpeed);
                leftLegFloat.gameObject.SetActive(false);
                runOnce4 = true; 
            }
        }
        
        if(gunHp <= 0 | (leftArmHp <= 0 & rightArmHp <= 0))
        {
             if(!runOnce)
            {
                GameObject ejectLarm = Instantiate(gun.gameObject, gun.position,gun.rotation);
                gun.gameObject.SetActive(false);
                Rigidbody ejectLarmB = ejectLarm.GetComponent<Rigidbody>();
                ejectLarmB.isKinematic = false;
                ejectLarmB.AddForce(ejectLarm.transform.forward * ejectSpeed);
                runOnce = true; 
            }   
        }
        if(torsoHp <= 0 & !runOnce5)
        {
            MechDisabled();
        }
        if(leftLegHp <= 0 | rightLegHp <= 0)
        {
            if(!runOnce5)
            {
                MechDisabled();
            }
        }
    }
    public void MechDisabled()
    {
        if(boss)
        {
            edc.bossKilled = true;
        }
        edc.enemyDeaths += 1f;
        engineNoise.Stop();
        headHoncho.GetComponent<NavMeshAgent>().enabled = false;
        headHoncho.GetComponent<enemyController>().enabled = false;
        headHonchoR.isKinematic = false;
        headHonchoR.AddForce(headHoncho.transform.forward * 1000f);      
        runOnce5 = true;
    }
}
