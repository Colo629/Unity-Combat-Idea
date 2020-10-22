using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDropPod : MonoBehaviour
{
    public leverLessEjection leverLessEjection;
    public Transform bossBody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        Instantiate(bossBody, transform.position, transform.rotation);
        leverLessEjection.ejectThis = true;
    }
}
