using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjectorManager : MonoBehaviour
{
    public MechStatusHolder msh;
    public Transform leftArm;
    public Transform leftLeg;
    public Transform rightLeg;
    public Transform rightArm;
    public Transform rightArmArmor;
    public Transform rightLegArmor;
    public Transform leftLegArmor;
    public Transform leftArmArmor;
    public GameObject thisObj;
    public bool runOnce1;
    public bool runOnce2;
    public bool runOnce3;
    public bool runOnce4;
    public bool runOnce5;
    public bool runOnce6;
    public float ejectSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RunEjection()
    {
        if(msh.ejectLeftArm == true & !runOnce1)
        {
            GameObject ejectLarm = Instantiate(leftArm.gameObject, leftArm.position,leftArm.rotation);
            leftArm.gameObject.SetActive(false);
            Rigidbody ejectLarmB = ejectLarm.GetComponent<Rigidbody>();
            ejectLarmB.isKinematic = false;
            ejectLarmB.AddForce(ejectLarm.transform.forward * ejectSpeed);
            runOnce1 = true; 
        }
        if(msh.ejectLeftArmArmor == true & !runOnce2)
        {
            GameObject ejectLarm = Instantiate(leftArmArmor.gameObject, leftArmArmor.position,leftArmArmor.rotation);
            leftArmArmor.gameObject.SetActive(false);
            Rigidbody ejectLarmB = ejectLarm.GetComponent<Rigidbody>();
            ejectLarmB.isKinematic = false;
            ejectLarmB.AddForce(ejectLarm.transform.forward * ejectSpeed);
            runOnce2 = true; 
        }
        if(msh.ejectRightArm == true & !runOnce3)
        {
            GameObject ejectLarm = Instantiate(rightArm.gameObject, rightArm.position,rightArm.rotation);
            rightArm.gameObject.SetActive(false);
            Rigidbody ejectLarmB = ejectLarm.GetComponent<Rigidbody>();
            ejectLarmB.isKinematic = false;
            ejectLarmB.AddForce(ejectLarm.transform.forward * ejectSpeed);
            runOnce3 = true; 
        }
        if(msh.ejectRightArmArmor == true & !runOnce4)
        {
            GameObject ejectLarm = Instantiate(rightArmArmor.gameObject, rightArmArmor.position,rightArmArmor.rotation);
            rightArmArmor.gameObject.SetActive(false);
            Rigidbody ejectLarmB = ejectLarm.GetComponent<Rigidbody>();
            ejectLarmB.isKinematic = false;
            ejectLarmB.AddForce(ejectLarm.transform.forward * ejectSpeed);
            runOnce4 = true; 
        }
        if(msh.ejectRightLegArmor == true & !runOnce5)
        { 
            GameObject ejectLarm = Instantiate(rightLegArmor.gameObject, rightLegArmor.position,rightLegArmor.rotation);
            rightLegArmor.gameObject.SetActive(false);
            Rigidbody ejectLarmB = ejectLarm.GetComponent<Rigidbody>();
            ejectLarmB.isKinematic = false;
            ejectLarmB.AddForce(ejectLarm.transform.forward * ejectSpeed);
            runOnce5 = true; 
        }
        if(msh.ejectLeftLegArmor == true & !runOnce6)
        {
            GameObject ejectLarm = Instantiate(leftLegArmor.gameObject, leftLegArmor.position,leftLegArmor.rotation);
            leftLegArmor.gameObject.SetActive(false);
            Rigidbody ejectLarmB = ejectLarm.GetComponent<Rigidbody>();
            ejectLarmB.isKinematic = false;
            ejectLarmB.AddForce(ejectLarm.transform.forward * ejectSpeed);
            runOnce6 = true; 
        }
    }
    public void ResetEjection()
    {
        runOnce1 = false;
        runOnce2 = false;
        runOnce3 = false;
        runOnce4 = false;
        runOnce5 = false;
        runOnce6 = false;
        if(msh.ejectLeftArm == false)
        {
            leftArm.gameObject.SetActive(true);
        }
        if(msh.ejectLeftArmArmor == false)
        {
            leftArmArmor.gameObject.SetActive(true);
        }
        if(msh.ejectRightArm == false)
        {
            rightArm.gameObject.SetActive(true);
        }
        if(msh.ejectRightArmArmor == false)
        {
            rightArmArmor.gameObject.SetActive(true);
        }
        if(msh.ejectRightLegArmor == false)
        {
            rightLegArmor.gameObject.SetActive(true);
        }
        if(msh.ejectLeftLegArmor == false)
        {
            leftLegArmor.gameObject.SetActive(true);
        }
    }
}
