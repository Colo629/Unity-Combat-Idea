using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monitorScript : MonoBehaviour
{   
    public Renderer viewPort;
    public Material onMaterial;
    public Material offMaterial;
    public bool cameraDestroyed;
    public engineScript engineScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!engineScript.engineOn)
        {
            viewPort.material = offMaterial;
        }
        if(cameraDestroyed == true)
        {
            viewPort.material = offMaterial;
        }
        if(engineScript.engineOn == true)
        {
            if(!cameraDestroyed)
            {
                viewPort.material = onMaterial;
            }
        }

        
        
    }
}
