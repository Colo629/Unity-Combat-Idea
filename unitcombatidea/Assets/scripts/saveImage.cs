using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class saveImage : MonoBehaviour
{
    public Texture2D tex2;
    public GameObject go;
    public Camera cam;

    public string partName = "";

    void Start()
    {
        //tex2 = (Texture2D)go.GetComponentInChildren<Renderer>().material.mainTexture;//GetTexture("_Color");
        //tex2 = ToTexture2D(tex);
        //File.WriteAllBytes(Application.dataPath + "/../SavedScreen2.png", tex2.EncodeToPNG());
        cam = GetComponent<CamInfo>().cam;
        go = gameObject;
    }

    void Update()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            Debug.Log("cumsock");
            tex2 = ToTexture2D(cam.activeTexture);
            File.WriteAllBytes(Application.dataPath  + "/Parts/" + partName + ".png", tex2.EncodeToPNG());          
        }
    }

    Texture2D ToTexture2D(RenderTexture rTex)
    {
        Texture2D tex = new Texture2D(1024, 1024, TextureFormat.RGB24, false);
        RenderTexture.active = rTex;
        tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
        tex.Apply();
        return tex;
    }
        
    
}
