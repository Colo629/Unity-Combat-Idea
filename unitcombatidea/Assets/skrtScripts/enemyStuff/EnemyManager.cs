using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    public AudioSource engineNoise;
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
    public bool runOnce = false;
    public bool runOnce1 = false;
    public bool runOnce2 = false;
    public bool runOnce3 = false;
    public bool runOnce4 = false;
    public bool runOnce5 = false;
    public bool runOnce6 = false;
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
        engineNoise.Stop();
        headHoncho.GetComponent<NavMeshAgent>().enabled = false;
        headHoncho.GetComponent<enemyController>().enabled = false;
        headHonchoR.isKinematic = false;
        headHonchoR.AddForce(headHoncho.transform.forward * 1000f);      
        runOnce5 = true;
    }
}
