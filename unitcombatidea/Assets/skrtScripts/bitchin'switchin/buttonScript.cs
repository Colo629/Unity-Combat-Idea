using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonScript : Switcher
{
    public bool buttonPressed;
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
        Debug.Log(other);
        if(!buttonPressed)
        {
            FindObjectOfType<AudioManager>().Play("beepSound");
            StartCoroutine(buttonCD());
        }
    }
    IEnumerator buttonCD()
    {
        buttonPressed = true;
        sendSwitch(true);
        yield return new WaitForSeconds(2);
        buttonPressed = false;
    }
}
