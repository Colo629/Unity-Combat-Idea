using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class partEjectorBuffer : switchAble
{
    public EjectorManager em;
    public MechStatusHolder msh;
    public buttonScript bS;
    public bool lla;
    public bool rla;
    public bool laa;
    public bool raa;
    public bool leftA;
    public bool rightA;
    public bool leftL;
    public bool rightL;
    
    public override void SetState(bool state)
    {
        if(lla)
        {
            msh.ejectLeftLegArmor = true;
            em.RunEjection();
        }
        if(rla)
        {
            msh.ejectRightLegArmor = true;
            em.RunEjection();
        }
        if(laa)
        {
            msh.ejectLeftArmArmor = true;
            em.RunEjection();
        }
        if(raa)
        {
            msh.ejectRightArmArmor = true;
            em.RunEjection();
        }
        if(leftA)
        {
            msh.ejectLeftArm = true;
            em.RunEjection();
        }
        if(leftL)
        {
            msh.ejectLeftLeg = true;
            em.RunEjection();
        }
        if(rightA)
        {
            msh.ejectRightArm = true;
            em.RunEjection();
        }
        if(leftA)
        {
            msh.ejectLeftArm = true;
            em.RunEjection();
        }
    }
    
  
}
