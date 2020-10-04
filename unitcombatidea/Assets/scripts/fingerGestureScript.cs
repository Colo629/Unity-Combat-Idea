using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class fingerGestureScript : MonoBehaviour
{
    public Collider indexBox;
    public Collider middleBox;
    public Collider ringBox;
    public Collider pinkyBox;
    public bool indexF;
    public bool middleF;
    public bool ringF;
    public bool pinkyF;
    public SteamVR_Action_Single rSqueeze;
    public SteamVR_Action_Single lSqueeze;
    public int summonNumberL;
    public int summonNumberR;
    public bool leftHand;
    
    //index finger = 1
    //index + pinky = 2
    // all but index = 3
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LockSymbols();
    }
    void LockSymbols()
    {
        if(!leftHand)
        {
            if (rSqueeze.axis > 0.6f )
            {
                if(indexF == true & pinkyF == false & ringF == false & middleF == false)
                {
                    summonNumberR = 1;
                    resetProtocol();
                }
                if(indexF == true & pinkyF == true & ringF == false & middleF == false)
                {
                    summonNumberR = 2;
                    resetProtocol();
                }
                if(indexF == false & pinkyF == true & ringF == true & middleF == true)
                {
                    summonNumberR = 3;
                    resetProtocol();
                }
                if(indexF == true & pinkyF == true & ringF == true & middleF == true)
                {
                    summonNumberR = 0;
                    resetProtocol();
                }
            }
        }
        if(leftHand)
        {
            if (lSqueeze.axis > 0.6f)
            {
                if(indexF == true & pinkyF == false & ringF == false & middleF == false)
                {
                    summonNumberL = 1;
                    resetProtocol();
                }
                if(indexF == true & pinkyF == true & ringF == false & middleF == false)
                {
                    summonNumberL = 2;
                    resetProtocol();
                }
                if(indexF == false & pinkyF == true & ringF == true & middleF == true)
                {
                    summonNumberL = 3;
                    resetProtocol();
                }
                if(indexF == true & pinkyF == true & ringF == true & middleF == true)
                {
                    summonNumberL = 0;
                    resetProtocol();
                }
            }
        }
    }
    void resetProtocol()
    {
        indexF = false;
        pinkyF = false;
        ringF = false;
        middleF = false;
    }
}
