using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mechDetector : MonoBehaviour
{
    public Collider thisCollider;
    public leverLessEjection lLE;
    void OnTriggerEnter(Collider other)
    {
        
        lLE.ejectThis = true;
        thisCollider.enabled = false;
    }
}
