using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViveGrabObject : MonoBehaviour
{
    public bool debugHold;
    public GameObject holdPosition;
    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device Controller
    {
        get
        {
            return SteamVR_Controller.Input((int)trackedObj.index);
        }
    
    }
    // Start is called before the first frame update
    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }
    public GameObject collidingObject; //To keep track of what objects have rigidbodies
    public GameObject objectInHand; // To track the object you're holding

    void OnTriggerEnter(Collider other) // Activate function in trigger zone, checking rigidbodies and ignoring if no
    {
        if (!other.GetComponent<Rigidbody>())
        {
            return;
        }
        collidingObject = other.gameObject; //If rigidbody, then assign object to collidingObject variable
    }
    // Update is called once per frame
    void Update()
    {
        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip)|debugHold) // Push grip buttons and touching object,
        {
            if (collidingObject)
            {
                debugHold = false;
                GrabObject();
            }
        }
        if (Controller.GetPressUp (SteamVR_Controller.ButtonMask.Grip)) // if release grip bottons and holding object
        {
            if (objectInHand)
            {
                ReleaseObject();
            }
        }
    }
        private void GrabObject() // Picking up object and assigning objectInHand variable
        {
            objectInHand = collidingObject;
            objectInHand.transform.SetParent (this.transform);
            objectInHand.GetComponent<Rigidbody>().isKinematic = true;
            objectInHand.transform.position = holdPosition.transform.position;
            objectInHand.transform.rotation = holdPosition.transform.rotation;
        }
    // Releasing object and disabling kinematic functionality so other forces can affect object
    private void ReleaseObject()
    {
        objectInHand.GetComponent<Rigidbody>().isKinematic = false;
        objectInHand.transform.SetParent (null);
    }
}
