using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechStatusHolder : MonoBehaviour
{
    public moveOnly ms;
    public float fuelCount;
    public float maxFuel;
    public float ammoCount;
    public float maxAmmo;
    public float magCount;
    public float maxMags;
    public float speedCounter;
    public bool flippyDippy;
    public bool requip;
    public float leftArmArmorCount;
    public float rightArmArmorCount;
    public float leftLegArmorCount;
    public float rightLegArmorCount;
    public float leftArmArmorMax;
    public float rightArmArmorMax;
    public float leftLegArmorMax;
    public float rightLegArmorMax;
    public float leftArmHp;
    public float leftArmMaxHp;
    public float rightArmHp;
    public float rightArmMaxHp;
    public float leftLegHp;
    public float leftLegMaxHp;
    public float rightLegHp;
    public float rightLegMaxHp;
    public float headHp;
    public float headMaxHp;
    public float torsoHp;
    public float torsoMaxHp;
    public Collider leftArmorA;
    public Collider rightArmorA;
    public Collider leftArmorL;
    public Collider rightArmorL;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ammoCount < 0)
        {
            ammoCount = 0;
        }
        if(requip == true)
        {
            requipProtocol();
        }
        if(fuelCount <= 0 & !flippyDippy)
        {
            ms.outOfFuel = true;
            flippyDippy = true;
        }
        if(fuelCount < 0)
        {
            fuelCount = 0;
        }
        if(fuelCount > 0 & flippyDippy == true)
        {
            ms.outOfFuel = false;
            flippyDippy = false;
        }
    }
    public void requipProtocol()
    {
        fuelCount = maxFuel;
        ammoCount = maxAmmo;
        magCount = maxMags;
        leftArmArmorCount = leftArmArmorMax;
        rightArmArmorCount = rightArmArmorMax;
        leftLegArmorCount = leftLegArmorMax;
        rightLegArmorCount = rightLegArmorMax;
        leftArmHp = leftArmMaxHp;
        rightArmHp = rightArmMaxHp;
        leftLegHp = leftLegMaxHp;
        rightLegHp = rightLegMaxHp;
        torsoHp = torsoMaxHp;
        leftArmorA.enabled = true;
        rightArmorA.enabled = true;
        leftArmorL.enabled = true;
        rightArmorL.enabled = true; 
        requip = false;   
    }
}
