using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour
{
    public SwitchManager switchManager;
    public string groupName;
    public virtual void sendSwitch(bool state)
    {
        switchManager.activateGroup(groupName, state);
    }
}
