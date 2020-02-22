using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gunBarrel;
    void Start()
    {
  
        Instantiate (
        gunBarrel,
        transform.position,
        Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
