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
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
        requip = false;
    }
}
