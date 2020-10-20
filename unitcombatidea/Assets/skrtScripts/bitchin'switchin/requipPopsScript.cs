using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class requipPopsScript : MonoBehaviour
{
    public AudioSource thisSource;
    public AudioSource thatSource;
    public AudioSource beepSource;
    
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
        thisSource.Stop();
        thatSource.Play();
        beepSource.Play();
        //StartCoroutine(DelayedOff());
    }
   public IEnumerator DelayedOff()
    {
        yield return new WaitForSeconds(5);
        
    }
}
