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
    public float outerCircleBound = 0.44f;
    public float innerCircleBound = 0.35f;
    public bool[] simpleGeometryArray = new bool[10];  // defines array of floats for future serialization of circle geometry
    public Texture2D drawnTexture;

    private float thetaIn;
    private float thetaOut;
    private bool inBounds = false;
    private float offset = 0;

    private int targetSides = -1;
    private int drawnVertices = 0;
    private bool poisoned = false;
    private bool drawing = false;
    private bool armedShape = false;
    private bool stagedShape = false;

    private bool spaghettiSpecial = true;

    private AlchemyCircle(float _circleSize, float _outerCircleBound, float _innerCircleBound)
    {
        circleSize = _circleSize;
        outerCircleBound = _outerCircleBound;
        innerCircleBound = _innerCircleBound;
    }

    /// <summary>
    /// Our main man, call each frame pen/chalk/finger is drawing.
    /// </summary>
    /// <param name="penPos"></param>
    public void Drawing(Vector3 penPos)
    {
        // if at some point during this drawing set, it became invalid,
        // do not attempt to create a shape definition
        if (poisoned)
        {
            targetSides = -2;
            Debug.Log("posioned drawingpenPos");
            return;
        }

        // your guess is as good as mine
        Vector3 localPos = transform.InverseTransformPoint(penPos);
        localPos = new Vector3(localPos.x, localPos.y, 0);
        float theta = GeoDetect.calcTheta(localPos.x, localPos.y);
        float distance = localPos.magnitude;

        Debug.Log("Theta: " + theta);

        // if you don't start at the start, you're dead kiddo
        if (drawing == false)
        {
            Debug.Log("Start Theta: " + theta);
            Debug.Log("Start Distance: " + distance);
            if (!GeoDetect.inStartBounds(theta))
            {
                Debug.Log("NOt In bounds!");
                poisoned = true;
                return;
            }
        }

        drawing = true;

        // if it's too far, shut it down
        if (distance > outerCircleBound)
        {
            Debug.Log("Too far: ");
            poisoned = true;
            return;
        }

        // if we are within the range of the outer circles
        if (distance > innerCircleBound)
        {
            // if this is the first frame we're in bounds
            if (!inBounds)
            {
                thetaIn = theta;
                inBounds = true;

                Debug.Log("Theta In");

                // if we're almost done with the shape, and we've
                // entered a boundary zone
                if (armedShape)
                {
                    // we only get one shot, one... something something spaghetti? 
                    armedShape = false;

                    // if we end in the startbounds, we stage 
                    // a shape for addition to the shape array
                    if (GeoDetect.inStartBounds(theta))
                    {
                        stagedShape = true;
                        Debug.Log("ended in start bounds");
                    }

                    // if you end the shape anywhere but the start... 
                    else
                    {
                        Debug.Log("Ended outside start");
                        poisoned = true;
                        
                    }
                }
            }
        }
        else
        {
            // if we are too close to be in the circles, 
            // and we were in the circles last frame
            if (inBounds)
            {
                thetaOut = theta;
                inBounds = false;
                if (spaghettiSpecial)
                {
                    Debug.Log("spaghetti: " + theta);
                    spaghettiSpecial = false;
                }
                else
                {
                    Debug.Log("not spaghetti: " + theta);
                    CornerEvent();
                    thetaIn = 0f;
                    thetaOut = 0f;
                }
            }
        }
    }

    /// <summary>
    /// I'm sure this will become helpful at some point.
    /// </summary>
    /// <param name="penPos"></param>
    public void StartDrawing(Vector3 penPos)
    {
        spaghettiSpecial = true;
        offset = 0;
        stagedShape = false;
        poisoned = false;
        targetSides = -1;
        drawing = false;
        drawnVertices = 0;
        thetaIn = -1f;
        thetaOut = -1f;
        Drawing(penPos);
    }

    /// <summary>
    /// Call when lifting drawing utensil, finishes off draw loop.
    /// </summary>
    /// <param name="penPos"></param>
    public void StopDrawing(Vector3 penPos)
    {
        // if we've staged a shape, and eveything worked,
        // we 'add' the shape to the bool array (tri = [3])
        if (!poisoned)
        {
            Debug.Log("Shape has this many sides: " + targetSides);
            simpleGeometryArray[targetSides] = true;
        }
        stagedShape = false;
        poisoned = false;
        targetSides = -1;
        drawing = false;
        drawnVertices = 0;
        thetaIn = -1f;
        thetaOut = -1f;
        offset = 0f;
    }

    private void CornerEvent()
    {
        

        // how much do we shift the shape zones by?
        if (targetSides > 0)
        {
            offset = (drawnVertices) * (360 / targetSides);
            Debug.Log("__Prepared Offset: " + offset);
        }
        
        int inSideCount = GeoDetect.ShapeCalc(thetaIn - offset);
        int outSideCount = GeoDetect.ShapeCalc(thetaOut - offset);

        Debug.Log("Corner Event: " + drawnVertices);
        Debug.Log("Shape sided-ness: " + inSideCount + ' ' + outSideCount + ' ' + offset);

        // if both entrance and exit of hitbound are the same shape boundary
        if (inSideCount == outSideCount)
        {
            // if neither of the GeoCalc's returned a usefull side indicator,
            // poison the draw cycle, and zero out target sides 
            if (inSideCount == 0)
            {
                poisoned = true;
                targetSides = 0;
                Debug.Log("inSidecount is zero so target sides set to 0");
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

            // if we've drawn enough sides, prepare a shape for addition
            // (barring screw-ups later on)
            if (drawnVertices + 1 == targetSides)
            {
                Debug.Log("Armed!");
                stagedShape = true;
            }
        }

        else
        {
            Debug.Log("Fisherman's fuckup");
            poisoned = true;
            return;
        }


    }






}
