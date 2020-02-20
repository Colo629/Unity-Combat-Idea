﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeoDetect
{
    // Upper boundaries of sequential angle multiples from zero
    private static float minBound = 41.8f;
    private static float octUpper = 48.2f;
    private static float septUpper = 55.7f;
    private static float hexUpper = 66f;
    private static float pentUpper = 81f;
    private static float sqrUpper = 105f;
    private static float triUpper = 135f;
    
    public void shapeTracker()
    {

    }

    public static int GeometryCalc(float theta)
    {
        if (theta < minBound){
            return 0;
        }
        else if (theta < octUpper)
        {
            return 8;
        }
        else if (theta < septUpper)
        {
            return 7;
        }
        else if (theta < hexUpper)
        {
            return 6;
        }
        else if (theta < pentUpper)
        {
            return 5;
        }
        else if (theta < sqrUpper)
        {
            return 4;
        }
        else if (theta < triUpper)
        {
            return 3;
        }
        else
        {
            return 0;
        }
    }
}