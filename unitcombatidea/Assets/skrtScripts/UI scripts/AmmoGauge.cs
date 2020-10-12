using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class AmmoGauge : MonoBehaviour
{
    public MechStatusHolder msh;
    public Gradient gradient;
    public Slider slider;
    public Image fill;
    public TMP_Text ammoDisplay;
    public TMP_Text magDisplay;
    public bool runItOnce;
    public bool runItOnce2;
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = msh.maxAmmo;
        slider.value = msh.ammoCount;
    }
    // Update is called once per frame
    void Update()
    {
        
        if(msh.ammoCount > 0)
        {
            ammoDisplay.text = msh.ammoCount.ToString();
            slider.value = msh.ammoCount;
            fill.color = gradient.Evaluate(slider.normalizedValue);
            runItOnce = false;
        }
        if(msh.ammoCount == 0 & !runItOnce)
        {
            ammoDisplay.text = msh.ammoCount.ToString();
            slider.value = msh.ammoCount;
            fill.color = gradient.Evaluate(slider.normalizedValue);
            runItOnce = true;
        }
        
        magDisplay.text = msh.magCount.ToString();
    }
}
