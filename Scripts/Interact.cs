using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    Camera cam;
    public float range = 3f;
    public GameObject interact;
    public bool interactable = false;
    public GameObject origin;
    bool holdingObject = false;

    GameObject grabbedObj;
    GameObject lastGrabbedObj;
    Rigidbody grabbedRb;
    Rigidbody lastGrabbedRb;
    public GameObject flashlight;
    bool isLit = false;
    public float smoothObjMove = 0.2f;
    public float maxGrabDist = 2f;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //Flashlight
        if(Input.GetKeyDown(KeyCode.F))
        {
            isLit = !isLit;
        }

        if(isLit){
            flashlight.SetActive(true);
        }else{
            flashlight.SetActive(false);
        }


        Vector3 grabPos = new Vector3(origin.transform.position.x, origin.transform.position.y, origin.transform.position.z);

        if(interactable){
            interact.SetActive(true);
        }else{
            interact.SetActive(false);
        }

        //Holding Objects
        if(holdingObject){
            
            lastGrabbedRb.useGravity = false;
            lastGrabbedObj.transform.position = Vector3.Lerp(lastGrabbedObj.transform.position, grabPos, Time.deltaTime * smoothObjMove);
            float distance = Vector3.Distance (lastGrabbedObj.transform.position, grabPos);
            holdingObject = true; 
            if(distance > maxGrabDist){
                lastGrabbedRb.useGravity = true;
                holdingObject = false;
            }
        }

        interactable = false;
        
        //Detect Objects
        Vector3 direction = cam.transform.forward;
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, range))
        {
            if(hit.collider.gameObject.tag == "weapon_pickup" || hit.collider.gameObject.tag == "door" || hit.collider.gameObject.tag == "ammo" || hit.collider.gameObject.tag == "grabbable"){
                interactable = true;
            }else{
                interactable = false;
            }
            //PickUp Objects
            if(!holdingObject){

                if(hit.collider.gameObject.tag == "weapon_pickup"){
                    WeaponPickUp weaponPickUp = hit.collider.gameObject.GetComponent<WeaponPickUp>();
                    if(Input.GetKeyDown(KeyCode.E)){
                        weaponPickUp.PickUp();
                    }
                }

                if(hit.collider.gameObject.tag == "door"){
                    Door door = hit.collider.gameObject.GetComponent<Door>();
                    
                    if(Input.GetKeyDown(KeyCode.E)){
                        door.Interact();
                    }
                }

                if(hit.collider.gameObject.tag == "ammo"){
                    PickUp ammo = hit.collider.gameObject.GetComponent<PickUp>();
                    
                    if(Input.GetKeyDown(KeyCode.E)){
                        ammo.Get();
                    }
                }
            }
            
            //Grab Objects
            if(hit.collider.gameObject.tag == "grabbable" || hit.collider.gameObject.tag == "weapon_pickup"){
                grabbedObj = hit.collider.gameObject;
                grabbedRb = grabbedObj.GetComponent<Rigidbody>();
                if(!holdingObject){
                    if(Input.GetKeyDown(KeyCode.Mouse2)){
                        lastGrabbedObj = grabbedObj;
                        lastGrabbedRb = grabbedRb;
                        holdingObject = true;   
                    }
                }
            
            }
            
            
        }

        Debug.DrawRay(cam.transform.position, direction * range, Color.green);

        //Drop Objects
    	if(holdingObject){
            if(Input.GetKeyUp(KeyCode.Mouse2)){
                lastGrabbedRb.useGravity = true;
                holdingObject = false;
            }
        }
        
    }
}


