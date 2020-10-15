using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionIndicator : MonoBehaviour
{
    public Renderer viewPort;
    public Material onMaterial;
    public Material offMaterial;
    public bool alarmOn;
    public Collider alarmCollider;
    public AudioManager audioManager;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        alarmOn = true;
        audioManager.Play("alarmSound");
    }
    void OnTriggerExit(Collider other)
    {
        alarmOn = false;
        audioManager.Stop("alarmSound");
    }
    void StartAlarm()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
        if(!alarmOn)
        {
            viewPort.material = offMaterial;
        }
        if(alarmOn)
        {
            viewPort.material = onMaterial;
        }
        
    }
}
