using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchManager : MonoBehaviour
{
    public SwitchLink[] links;
    public void activateGroup(string groupName , bool state)
    {
        for(int i = 0; i < links.Length;i++)
        {
            if(links[i].groupName == groupName)
            {
                for(int j = 0; j < links[i].switchAbles.Length; j++)
                {
                  links[i].switchAbles[j].SetState(state);
                }
            }
        }
    }
}
