using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class requipBuffer : switchAble
{
    public buttonScript bs;
    public bool on;
    public bool shotgun;
    public bool autoCannon;
    public bool revoRifle;
    public GameObject spawnThis;
    public Transform spawnPoint;
    
    
    public override void SetState(bool state)
    {
        if(!on)
        {
            if(shotgun)
            {
                Instantiate(spawnThis,spawnPoint.position, spawnPoint.rotation);
            }
            if(autoCannon)
            {
                Instantiate(spawnThis, spawnPoint.position, spawnPoint.rotation);
            }
            if(revoRifle)
            {   
                Instantiate(spawnThis, spawnPoint.position, spawnPoint.rotation);
            }
            on = true;
        }
    }
}
