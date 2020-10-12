using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequipPod : MonoBehaviour
{
    public MechStatusHolder msh;
    public playerManager playerScript;
    void Start()
    {
        msh = playerScript.player.GetComponent<MechStatusHolder>();
    }
    void OnTriggerEnter(Collider other)
    {
        msh.requip = true;
    }
    void OnTriggerExit(Collider other)
    {
        msh.requip = false;
    }
}
