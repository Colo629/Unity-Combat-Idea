using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getCanvasScript : MonoBehaviour
{
    public GameObject canvas;
    private saveImage saveImage;
    private CamInfo camInfo;
    // Start is called before the first frame update
    void awake()
        {
         saveImage = canvas.GetComponent<saveImage>();
         camInfo = canvas.GetComponent<CamInfo>();
        }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
