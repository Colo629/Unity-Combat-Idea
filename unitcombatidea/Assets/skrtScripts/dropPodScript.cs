using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropPodScript : MonoBehaviour
{
    public GameObject mechBody;
    public GameObject gunMover;
    public GameObject mechSword;
    public GameObject gunBarrelBigly;
    public GameObject switchWeapon;
    public Transform mechBodyTransform;
    public bool popDrop;
    public bool firstPop;
    public GameObject dropPodBottom;
    public Rigidbody mechRigidBody;
    public partEjectorScript frontWall;
    public partEjectorScript leftWall;
    public partEjectorScript rightWall;
    public partEjectorScript backWall;
    public partEjectorScript roof;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(popDrop & !firstPop)
        {
            mechRigidBody.isKinematic = false;
            mechBody.GetComponent<moveOnly>().enabled = true;
            gunMover.GetComponent<swordScript>().enabled = true;
            gunMover.GetComponent<gunControlScript>().enabled = true;
            mechSword.GetComponent<swordScript>().enabled = true;
            gunBarrelBigly.GetComponent<gunScript>().enabled = true;
            switchWeapon.GetComponent<switchWeapons>().enabled = true;
            flipEjectors();
            mechBodyTransform.parent = null;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        
            if(dropPodBottom.tag == "dropPod")
            {
                Debug.Log("grounded");
                popDrop = true;
                

            }
    }
    public void flipEjectors()
    {
        roof.leverPulled = true;
        frontWall.leverPulled = true;
        leftWall.leverPulled = true;
        rightWall.leverPulled = true;
        backWall.leverPulled = true;
    }
}
