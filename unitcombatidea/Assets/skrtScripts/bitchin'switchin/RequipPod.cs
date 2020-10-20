using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequipPod : MonoBehaviour
{
    public MechStatusHolder msh;
    public playerManager playerScript;
    public bool shotgunDrop;
    public bool revoDrop;
    public bool autoCannonDrop;
    public bool oneUse;
    public leverLessEjection lLE;
    public bool set;
    public GameObject gumRat;
    public Rigidbody topDrop;
    public AudioSource beepSource;

    
    void Start()
    {
        
    }
    public void ActivateThis()
    {
       
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(!oneUse)
        {
            msh = other.transform.GetComponentInParent<MechStatusHolder>();
            StartCoroutine(waitForRearm());
        } 
    }
    
    void OnTriggerExit(Collider other)
    {
        msh.requip = false;    
    }
    
    public IEnumerator waitForRearm()
    {
        beepSource.Stop();
        msh.mechCommandPlat.GetComponent<Rigidbody>().isKinematic = true;
        msh.ms.enabled = false;
        yield return new WaitForSeconds(5);
        msh.ms.enabled = true;
        msh.requip = true;
        GunChange();
        msh.mechCommandPlat.GetComponent<Rigidbody>().isKinematic = false;
        lLE.ejectThis = true;
        oneUse = true;
        

    }
    public void GunChange()
    {
         if(shotgunDrop)
        {
            msh.shotgun = true;
            msh.gunChange = true;
        }
        if(revoDrop)
        {
            msh.revoRifle = true;
            msh.gunChange = true;
        }
        if(autoCannonDrop)
        {
            msh.autoCannon = true;
            msh.gunChange = true;
        }
    }
}
