using System.Collections;
using System.Collections.Generic;
using UnityEngine;
   // [RequireComponent(typeof(Camera))]
public class drawScript : MonoBehaviour
{
    // Start is called before the first frame update
    private new Camera camera;
    public Material lineMaterial;
    public float lineWidth;
    public float depth = 5;
    private Vector3? lineStartPoint = null;
    public GameObject chalkTip;
    private bool triggered;
    private bool exit;
    private bool stay;
    public GameObject canvas;
    public Camera canvasCam;
    public GameObject chalkVis;
    public GameObject raycastVis;
    public LayerMask canvasLayer;

    private Vector3 recentPoint;

    public AlchemyCircle alchCircle;


    void OnTriggerExit(Collider other)
    {
        chalkVis.transform.position = chalkVis.transform.TransformPoint(new Vector3());
        exit = true;
        stay = false;
        
        canvasCam = null;
        alchCircle.StopDrawing(transform.position);
        alchCircle = null;
    }

    void OnTriggerEnter(Collider other)
    {
        
        canvas = other.gameObject;  
        triggered = true;
        canvasCam = canvas.GetComponent<CamInfo>().cam;
        alchCircle = other.GetComponent<AlchemyCircle>();
        alchCircle.StartDrawing(transform.position);

    }
    void OnTriggerStay(Collider other)
    {
        stay = true;
        alchCircle.Drawing(transform.position);
    }
    

    void Start()
    {
        camera = GetComponent<Camera>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered)
        {

            lineStartPoint = GetMouseCameraPoint();
            triggered = false;
        }
        else if (stay)
        {
            var lineEndPoint = GetMouseCameraPoint();
            var gameObject = new GameObject();
            var lineRenderer = gameObject.AddComponent<LineRenderer>();
            lineRenderer.material = lineMaterial;
            // lineRenderer.positionCount = 2;
            lineRenderer.SetPositions(new Vector3[] { lineStartPoint.Value, lineEndPoint });
            lineRenderer.startWidth = lineWidth;
            lineRenderer.endWidth = lineWidth;
            lineStartPoint = GetMouseCameraPoint();
        }
        else if (exit)
        {
            if (!lineStartPoint.HasValue)
            {
                return;
            }
            exit = false;

            var lineEndPoint = GetMouseCameraPoint();
            var gameObject = new GameObject();
            var lineRenderer = gameObject.AddComponent<LineRenderer>();
            lineRenderer.material = lineMaterial;
            // lineRenderer.positionCount = 2;
            lineRenderer.SetPositions(new Vector3[] { lineStartPoint.Value, lineEndPoint });
            lineRenderer.startWidth = lineWidth;
            lineRenderer.endWidth = lineWidth;

            lineStartPoint = null;
        }

    }

     Vector3 GetMouseCameraPoint()
    {
       // int layerMask = 1 << 9;
        RaycastHit hit;
        //Physics.Raycast(raycastVis.transform.position, raycastVis.transform.up, out hit, Mathf.Infinity, ~layerMask);
        Physics.Raycast(raycastVis.transform.position, raycastVis.transform.up, out hit, Mathf.Infinity, canvasLayer.value ); // my testing
        //Debug.Log(hit.collider.gameObject.name);
        //Debug.Log(~layerMask);
        //Debug.Log(canvasLayer.value);
        //Debug.Log(hit.textureCoord);
        Vector3 visHolder = chalkVis.transform.InverseTransformPoint(hit.point); //no change needed afaik
        float floatScale = (0.02963647f / 2); //my testing showed lower value = less acceleration on pushback
        
        chalkVis.transform.position = chalkVis.transform.TransformPoint(new Vector3(0, visHolder.y - 0.5f, 0)); // determines how far chalk moves back +constantly? Also drawing point to bottom left hmm.
        Vector3 pointHolder = new Vector3(hit.textureCoord.x, hit.textureCoord.y, depth);
        pointHolder = canvasCam.transform.position + new Vector3(2 * (pointHolder[0]-0.5f),2 * (pointHolder[1]-0.5f),depth); //changes where the drawing occurs on the canvas

        recentPoint = pointHolder;

        //var ray = camera.ScreenPointToRay(Input.mousePosition);
        //return ray.origin + ray.direction * depth;
        return pointHolder;
    }
}

// summation of problems: going forward not backwards, not "drawing"
// it is drawing it's just getting increasing smaller AND the smaller it gets the more it heads to the bottom left corner of the canvas
// in fact it gets so small you cant see it on the canvas, have to go to the object and zoom in