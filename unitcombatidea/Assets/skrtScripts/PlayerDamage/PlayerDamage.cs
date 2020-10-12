using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public MechStatusHolder msh;
    public bool lAA;
    public bool rAA;
    public bool lLA;
    public bool rLA;
    public bool head;
    public bool torso;
    public bool notArmor;
    public Collider collisionData;
    public AIBulletScript aiBS;
    public Collider thisPart;
    public ArmorStatus armorStatus;
    // Start is called before the first frame update
    void Start()
    {
    
    }
    public void OnTriggerEnter(Collider collisionData)
    {
        if(collisionData.tag == "AIDamage")   //make sure to check AI bullets tags
        {
            aiBS = collisionData.gameObject.GetComponent<AIBulletScript>();
            if(!notArmor)
            {
                    if(lAA)
                {
                    armorStatus.updateArmorStatus();
                    msh.leftArmArmorCount -= aiBS.damageValue;
                    if(msh.leftArmArmorCount <= 0)
                    {
                    msh.leftArmorA.enabled = false;
                    armorStatus.updateArmorStatus();
                    }
                }
                if(rAA)
                {
                    armorStatus.updateArmorStatus();
                    msh.rightArmArmorCount -= aiBS.damageValue;
                    if(msh.leftArmArmorCount <= 0)
                    {
                        msh.rightArmorA.enabled = false;
                        armorStatus.updateArmorStatus();
                    }
                }
                if(lLA)
                {
                    armorStatus.updateArmorStatus();
                    msh.leftLegArmorCount -= aiBS.damageValue;
                    if(msh.leftLegArmorCount <= 0)
                    {
                        msh.leftArmorL.enabled = false;
                        armorStatus.updateArmorStatus();
                    }
                }
                if(rLA)
                {
                    armorStatus.updateArmorStatus();
                    msh.rightLegArmorCount -= aiBS.damageValue;
                    if(msh.rightLegArmorCount <= 0)
                    {
                        msh.rightArmorL.enabled = false;
                        armorStatus.updateArmorStatus();
                    }
                }
            }
            if(notArmor)
            {
                //write a different function for taking damage on base models.
            }
            
        }
    }
    void OnTriggerExit(Collider collisionData)
    {
        armorStatus.updateArmorStatus();
        collisionData = null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
