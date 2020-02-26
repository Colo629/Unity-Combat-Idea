﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class SmoothMove : MonoBehaviour
{
    public SteamVR_Action_Vector2 moveAxis;
    public SteamVR_Action_Boolean lockAxis;
    public GameObject playerBody;

    void Update()
    {
        if (lockAxis.GetState(SteamVR_Input_Sources.LeftHand))
        {
            Vector3 playerPos = playerBody.transform.position;
            Vector3 contCoords = moveAxis.GetAxis(SteamVR_Input_Sources.LeftHand);
            contCoords = new Vector3(contCoords.x, 0, contCoords.y);
            playerPos = playerPos + transform.TransformPoint(contCoords * Time.deltaTime);
        }
        else if (lockAxis.GetState(SteamVR_Input_Sources.RightHand))
        {
            Vector3 playerPos = playerBody.transform.position;
            Vector3 contCoords = moveAxis.GetAxis(SteamVR_Input_Sources.RightHand);
            contCoords = new Vector3(contCoords.x, 0, contCoords.y);
            playerPos = playerPos + transform.TransformPoint(contCoords * Time.deltaTime);
        }
    }
}
