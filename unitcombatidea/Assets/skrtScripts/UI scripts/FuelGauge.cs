using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelGauge : MonoBehaviour
{
    public MechStatusHolder msh;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = msh.maxFuel;
        slider.value = msh.fuelCount;
    }
    // Update is called once per frame
    void Update()
    {
        if(msh.fuelCount > 0)
        {
            slider.value = msh.fuelCount;
        }
    }
}
