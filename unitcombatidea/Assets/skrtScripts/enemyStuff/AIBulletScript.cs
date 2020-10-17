﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBulletScript : MonoBehaviour
{
    public float damageValue;
    public float fireRate;
    public float dispersion;
    public bool firing;
    public Transform firePos;
    private float roundsToFire;
    private float roundsPerSecond;
    public GameObject aiBullet;
    public float ammoPool;
    public float maxAmmo = 60; 
    public float reloadTime = 3f;
    public float magCount = 6f;
    public bool startReload;
    void Start()
    {
        roundsPerSecond = fireRate/60;
    }
    // Update is called once per frame
    void Update()
    {
        if(firing & ammoPool > 0 & !startReload)
        {
            CalculateRounds();
        }
        if(firing & ammoPool <= 0 & !startReload)
        {
            ReloadProtocol();
        }
        if(!firing & ammoPool <= 15 & !startReload)
        {
            ReloadProtocol();
        }
    }
    private void CalculateRounds()
    {
        roundsToFire += roundsPerSecond * Time.deltaTime;
        while(roundsToFire >= 1)
        {
            FireGun();
        }
    }
    private void FireGun()
    {
        Quaternion aimVector = Quaternion.RotateTowards(transform.rotation,Random.rotation,dispersion);
        GameObject instBullet = Instantiate(aiBullet,transform.position,aimVector) as GameObject;
        //reduce ammopoool by one
        roundsToFire -= 1;
        ammoPool -= 1;
    }
    private void ReloadProtocol()
    {
        startReload = true;
        ammoPool = 0f;
        if(magCount > 0)
        {
            StartCoroutine(WaitForReload());
        }
        
        
    }
    IEnumerator WaitForReload()
    {
        yield return new WaitForSeconds(reloadTime);
        ammoPool = maxAmmo;
        magCount -= 1;
        startReload = false;   
    }

}
