using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class spawnerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hypercube;
    void Start(){ 
        Instantiate (
        hypercube,
        transform.position,
        Quaternion.identity);
    
     }
    // Update is called once per frame
    void Update()
    {
 
    }
        
    
}
