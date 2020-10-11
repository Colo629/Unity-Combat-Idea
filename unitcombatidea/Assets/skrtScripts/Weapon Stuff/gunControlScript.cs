using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class gunControlScript : MonoBehaviour
{
    public bool rightHand;
    public leverScript leverR;
    public leverScript leverL;
    public Transform gunHandle;
    public Transform mech;
    public Vector3 relativePosition;
    public Transform rotateRef;
    public float multiplier = 1;
    public Vector3 relativeRotation2;
    public bool cocked;
    public bool fired = false;
    public bool firing;
    public Vector3 stabReset2;
    public SteamVR_Action_Single rightMechTrigger;
    public bool doublePull;
    public Vector3 handleMovement;
    public bool setAngle = false;
    public bool hammerDown = false;
    public float ammoPool = 0;
    public float magSize = 0;
    public bool triggerPulled;
    private IEnumerator coroutine;
    public float fireRPM = 0;
    public bool firstShot;
    public bool startReload;
    public bool finishReload;
    public bool twist1;
    public bool twist2;
    public bool startTwist;
    public bool stopTwist;
    public GameObject ammoDrum;
    public GameObject dropDrum;
    public GameObject magHolder;
    public bool firstDrop;
    public Renderer magRender;
    public Transform reloaderGrip;
    public bool lockReloader;
    public Vector3 handleMovement2;
    public gunScript gS;
    public swordScript swordScript; //just here for demonstration not gunna stay this way
    public swordScript bayonettScript;
    public Transform gunTopLevel; // temporary just for demonstration
    public bool destroyed;
    public bool switchToMeleeB;
    public SteamVR_Action_Boolean switchToMelee;
    public SteamVR_Input_Sources rightHand2;
    public bool backsway;
    public bool press1;
    public bool stopRunning;
    public MechStatusHolder msh;
    public bool lockReload;
    
    //vvvvv get rid of when learn to use for loops lmao vvvv
    public Renderer r19;
    public Renderer r18;
    public Renderer r17;
    public Renderer r16;
    public Renderer r15;
    public Renderer r14;
    public Renderer r13;
    public Renderer r12;
    public Renderer r11;
    public Renderer r10;
    public Renderer r9;
    public Renderer r8;
    public Renderer r7;
    public Renderer r6;
    public Renderer r5;
    public Renderer r4;
    public Renderer r3;
    public Renderer r2;
    public Renderer r1;
    // Start is called before the first frame update
    void Start()
    {
        msh.ammoCount = magSize;
    }

    // Update is called once per frame
    void Update()
    {  
        if(destroyed & !stopRunning)
            {   
                r19.enabled = false; 
                r18.enabled = false;
                r17.enabled = false;
                r16.enabled = false;
                r15.enabled = false;
                r14.enabled = false;
                r13.enabled = false;
                r12.enabled = false;
                r11.enabled = false;
                r10.enabled = false;
                r9.enabled = false;
                r8.enabled = false;
                r7.enabled = false;
                r6.enabled = false;
                r5.enabled = false;
                r4.enabled = false;
                r3.enabled = false;
                r2.enabled = false;
                r1.enabled = false;
                stopRunning = true;
            }
        if(!destroyed)
        {
            if(!switchToMeleeB)
            {      
                triggerSolution();
                if(leverR.grabbed == true)
                {
                    controlGunProtocol();
                    if(triggerPulled)
                        {
                            fireGunProtocol();
                        }
                }
                reloadGunProtocol();
            }
            if(switchToMelee.GetStateDown(rightHand2) == true)
            {
                if(!switchToMeleeB & !backsway)
                {
                    switchToMeleeB = true;
                    press1 = true;
                }
                if(switchToMeleeB & backsway)
                {
                    switchToMeleeB = false;
                    press1 = false;
                    backsway = false;
                }
            }
            if(switchToMelee.GetStateDown(rightHand2) == false)
            {
                if(press1)
                {
                    backsway = true;
                }
            }
            if(!switchToMeleeB)
            {
                bayonettScript.activateSword = false;
            }
            if(switchToMeleeB & !destroyed)
            {
                bayonettScript.activateSword = true;
            }
        }
    }

    void triggerSolution()
    {
        if(rightMechTrigger.axis >= 0.93f)
        {
            triggerPulled = true;
        }
        if(rightMechTrigger.axis < 0.73f)
        {
            triggerPulled = false;
            firstShot = false;
            fired = false;
        }
    }

    void controlGunProtocol()
    {
        
        float zValue = (leverR.output.z * multiplier * 1.5f) - 40f; //push/pull
        float yValue = (leverR.output.y * multiplier); //lateral movement
        float xValue = (leverR.output.x * (multiplier/1.5f)) - 60f; //rotate
        gunHandle.localEulerAngles = new Vector3(0,-xValue,0);
        rotateRef.localEulerAngles = new Vector3(-zValue,0,0);
    }

    void fireGunProtocol()
    {
        if(!firstShot)
        {    
            fired = true;
            gS.fireGun();
            firstShot = true;       
        }
        if(fired == true & firstShot == true)
        {
            StartCoroutine(Shoot());
        }
    }
    IEnumerator Shoot()
    {         
        fired = false;
        yield return new WaitForSeconds(1/(fireRPM/60));
        fired = true;
        gS.fireGun();
    }
    void reloadGunProtocol()
    {
        // ^^^^ use values for movement of the reloader
        if(!lockReloader)
        {
            float zValue = (leverL.output.z * multiplier/100) - 1.5f; //push/pull
            float yValue = (leverL.output.y * multiplier);
            float xValue = (leverL.output.x * multiplier); //rotate\
            handleMovement2 = new Vector3(-0.11f,0.05f,-zValue);
            handleMovement2 = rotateRef.TransformPoint(handleMovement2);
            reloaderGrip.position = handleMovement2;  
        }
        if(!startReload)
        {
            if(leverL.output.z > 0.18f & msh.magCount > 0)
            {
                lockReloader = true;
                startReload = true;
                msh.ammoCount = 0;
                //shut off forward movement
                //enable twisting to grab the ammo barrel
            }
            if(leverL.output.z > 0.18f & msh.magCount == 0)
            {
                startReload = true;
                lockReloader = false;
                msh.ammoCount = 0;
            }
        }
        if(startReload == true)
        {
            if(!firstDrop)
            {
                magRender.enabled = false;
                Instantiate(dropDrum,magHolder.transform.position,magHolder.transform.rotation); 
                firstDrop = true;
            }                    
            if(leverL.output.x < 0.10f & msh.magCount > 0) // check to see the hand untwisted after drawback
            {
                startTwist = true;
            }
            if(msh.magCount == 0)
            {
                lockReload = false;
            }
            if(startTwist == true)
            {
                if(leverL.output.x > 0.65f) // twisting left to grab mag
                {
                    twist1 = true;
                }
                if(twist1 == true)
                {
                    if(leverL.output.x < 0.10f) //twisting back to put mag in gun
                    {
                        twist2 = true;
                    }
                }
                if(twist2 == true) //pushing the reloader forward and putting the bolt into battery
                {
                    magRender.enabled = true;
                    lockReloader = false;
                    startTwist = false;
                    if(leverL.output.z < 0.05)
                    {   
                        msh.magCount -= 1;
                        finishReload = true;
                    }
                }
            }
        }

        if(finishReload)
        {          
            firstDrop = false;
            startTwist = false;
            twist1 = false;
            twist2 = false;
            startReload = false;
            msh.ammoCount = magSize;
            finishReload = false;
        }
    }
    
}
