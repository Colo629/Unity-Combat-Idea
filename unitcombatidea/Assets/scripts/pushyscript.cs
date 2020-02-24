using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushyscript : MonoBehaviour
{
    public float speed = 3f;
   
    // Start is called before the first frame update
    void Start()
    {
    
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += transform.forward.normalized * Time.deltaTime * speed;
    }
}
