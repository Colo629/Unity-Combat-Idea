﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechStatusHolder : MonoBehaviour
{
    public ArmorStatus armorStatus;
    public AmmoGauge ammoGauge;
    public EjectorManager em;
    public gunControlScript gcs;
    public moveOnly ms;
    public Transform mechCommandPlat;
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
    public GameObject equipedGun;
    public bool gunChange;
    public bool shotgun;
    public GameObject shotgunR;
    public bool autoCannon;
    public GameObject autoCannonR;
    public GameObject musketR;
    public bool musket;
    public bool pump;
    public bool fullAuto;
    public bool disabledLeftArm;
    public bool disabledRightArm;
    public bool disabledRightLeg;
    public bool disabledLeftLeg;
    public bool disabledTorso;
    public bool disabledHead;
    public bool bothDestroyed;
    public bool ejectLeftArmArmor;
    public bool ejectRightArmArmor;
    public bool ejectLeftLegArmor;
    public bool ejectRightLegArmor;
    public bool ejectLeftArm;
    public bool ejectRightArm;
    public bool ejectRightLeg;
    public bool ejectLeftLeg;
    

    // Start is called before the first frame update
    void Start()
    {
        gcs = equipedGun.GetComponentInChildren<gunControlScript>();
        if(gcs.pump == true)
        {
            pump = true;
        }
        if(gcs.fullAuto == true)
        {
            autoCannon = true;
        }
        if(gcs.musket)
        {
            musket = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(disabledLeftArm & disabledLeftLeg)
        {
            bothDestroyed = true;
        }
        if(gunChange)
        {
            GunChangeProtocol();
        }
        
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
        disabledLeftArm = false;
        disabledRightArm = false;
        disabledRightLeg = false;
        disabledLeftLeg = false;
        bothDestroyed = false;
        ejectLeftArmArmor = false;
        ejectRightArmArmor =false;
        ejectLeftLegArmor = false;
        ejectRightLegArmor = false;
        ejectLeftArm = false ;
        ejectRightArm = false;
        ejectRightLeg = false;
        ejectLeftLeg = false;
        disabledTorso = false;
        disabledHead = false;
        em.ResetEjection();
        armorStatus.updateArmorStatus();
        ammoGauge.RefreshAmmoGauge();
        requip = false;   
    }
    public void GunChangeProtocol()
    {
        equipedGun.SetActive(false);
        if(shotgun)
        {
            shotgunR.SetActive(true);
            equipedGun = shotgunR;
            pump = true;
            shotgun = false;
            musket = false;
            fullAuto = false;
            autoCannon = false;
            musket = false;
        }
        if(musket)
        {
            musketR.SetActive(true);
            equipedGun = musketR;
            pump = false;
            autoCannon = false;
            fullAuto = false;
            musket = true;
        }
        if(autoCannon)
        {
            autoCannonR.SetActive(true);
            equipedGun = autoCannonR;
            pump = false;
            autoCannon = true;
            musket = false;
            fullAuto = true;
        }
        gcs = equipedGun.GetComponentInChildren<gunControlScript>();
        gcs.RefreshAmmoProtocol();
        gunChange = false;

    }
}
