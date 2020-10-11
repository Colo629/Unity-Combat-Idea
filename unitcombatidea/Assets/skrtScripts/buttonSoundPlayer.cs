using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonSoundPlayer : switchAble
{
    public buttonScript buttonScript;
    public bool on;
    public string soundName;
    public AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(buttonScript.buttonPressed == true & !on)
        {
            audioManager.Play(soundName);
            //FindObjectOfType<AudioManager>().Play(soundName);
            on = true;
        }*/
        
        //if(buttonScript.buttonPressed == true & on)
        //{
            //FindObjectOfType<AudioManager>().Stop("rulesOfNature");
            //on = false;
       // }   
    }
    public override void SetState(bool state)
    {
        if(!on)
        {
            audioManager.Play(soundName);
            on = true;
        }
    }
}
