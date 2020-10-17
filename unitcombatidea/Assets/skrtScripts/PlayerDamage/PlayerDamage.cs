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
    public bool leftArm;
    public bool rightArm;
    public bool leftLeg;
    public bool rightLeg;
    public bool notArmor;
    public AIBulletScript aiBS;
    public Collider thisPart;
    public ArmorStatus armorStatus;
    // Start is called before the first frame update
    void Start()
    {
    
    }
    public void DamageThis(float damage)
    {  
            if(!notArmor)
            {
                    if(lAA)
                {
                    armorStatus.updateArmorStatus();
                    msh.leftArmArmorCount -= damage;
                    if(msh.leftArmArmorCount <= 0)
                    {
                    msh.leftArmorA.enabled = false;
                    armorStatus.updateArmorStatus();
                    }
                }
                if(rAA)
                {
                    armorStatus.updateArmorStatus();
                    msh.rightArmArmorCount -= damage;
                    if(msh.leftArmArmorCount <= 0)
                    {
                        msh.rightArmorA.enabled = false;
                        armorStatus.updateArmorStatus();
                    }
                }
                if(lLA)
                {
                    armorStatus.updateArmorStatus();
                    msh.leftLegArmorCount -= damage;
                    if(msh.leftLegArmorCount <= 0)
                    {
                        msh.leftArmorL.enabled = false;
                        armorStatus.updateArmorStatus();
                    }
                }
                if(rLA)
                {
                    armorStatus.updateArmorStatus();
                    msh.rightLegArmorCount -= damage;
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
                if(leftArm)
                {
                    armorStatus.updateArmorStatus();
                    msh.leftArmHp -= damage;
                    if(msh.leftArmHp <= 0)
                    {
                        msh.disabledLeftArm = true;
                        armorStatus.updateArmorStatus();
                    }
                }
                 if(leftLeg)
                {
                    armorStatus.updateArmorStatus();
                    msh.leftLegHp -= damage;
                    if(msh.leftLegHp <= 0)
                    {
                        msh.disabledLeftLeg = true;
                        armorStatus.updateArmorStatus();
                    }
                }
                 if(rightArm)
                {
                    armorStatus.updateArmorStatus();
                    msh.rightArmHp -= damage;
                    if(msh.rightArmHp <= 0)
                    {
                        msh.disabledRightArm = true;
                        armorStatus.updateArmorStatus();
                    }
                }
                if(rightLeg)
                {
                    armorStatus.updateArmorStatus();
                    msh.rightLegHp -= damage;
                    if(msh.rightLegHp <= 0)
                    {
                        msh.disabledRightLeg = true;
                        armorStatus.updateArmorStatus();
                    }
                }
                if(torso)
                {
                    armorStatus.updateArmorStatus();
                    msh.torsoHp -= damage;
                    if(msh.torsoHp <= 0)
                    {
                        msh.disabledTorso = true;
                        armorStatus.updateArmorStatus();
                    }
                }
            } 
        armorStatus.updateArmorStatus();      
    }
}
