using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


/// <summary>
/// Class AlchemyCircle descibes an alchemical circle, and is serializable. 
/// </summary>
[System.Serializable]
public class AlchemyCircle : MonoBehaviour
{
    public float circleSize = 1f;
    public float outerCircleBound = 1f;
    public float innerCircleBound = 0.95f;
    public float[] simpleGeometryArray = new float[20];  // defines array of floats for future serialization of circle geometry
    public Texture2D drawnTexture;

    private float thetaIn;
    private float thetaOut;

    private int targetSides = -1;
    private int drawnVertices = 0;
    private bool poisoned = false;
    private bool drawing = false;

    private AlchemyCircle(float _circleSize, float _outerCircleBound, float _innerCircleBound)
    {
        circleSize = _circleSize;
        outerCircleBound = _outerCircleBound;
        innerCircleBound = _innerCircleBound;
    }

    public void Drawing(Vector3 penPos)
    {

    }

    public void StartDrawing(Vector3 penPos)
    {

    }

    public void StopDrawing(Vector3 penPos)
    {

    }

    private void CornerEvent(float thetaIn, float thetaOut)
    {
        int inSideCount = GeoDetect.GeometryCalc(thetaIn);
        int outSideCount = GeoDetect.GeometryCalc(thetaOut);

        // if both entrance and exit of hitbound are the same shape boundary
        if (inSideCount == outSideCount)
        {
            // if neither of the GeoCalc's returned a usefull side indicator,
            // poison the draw cycle, and zero out target sides 
            if (inSideCount == 0)
            {
                poisoned = true;
                targetSides = 0;
                return;
            }

            // if the circle doesn't have a shape in mind for the current
            // draw cycle, set it to the result of the GeometryCalc
            if (targetSides == -1)
            {
                targetSides = inSideCount;
            }

            // if you hit the wrong side indicator, you dun goofed
            else if (targetSides != inSideCount)
            {
                poisoned = true;
                targetSides = 0;
                return;
            }

            // if all else goes well, increase the drawn vertex count
            drawnVertices++;
        }


    }






}
