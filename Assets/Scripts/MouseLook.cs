using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSpeed = 3;
    public Transform playerT;
    public Camera Cam;

    PauseMenu pauseMenu;
    GameObject gameManager;

    private void Start() {
        gameManager = GameObject.FindGameObjectWithTag("gameManager");
        pauseMenu = gameManager.GetComponent<PauseMenu>();
    }

    private void Update()
    {

        if(!pauseMenu.paused){
            float X = Input.GetAxis("Mouse X") * mouseSpeed;
            float Y = Input.GetAxis("Mouse Y") * mouseSpeed;

            playerT.Rotate(0, X, 0);

            if (Cam.transform.eulerAngles.x + (-Y) > 80 && Cam.transform.eulerAngles.x + (-Y) < 280)
            { }
            else
            {
                Cam.transform.RotateAround(Cam.transform.position, Cam.transform.right, -Y);
            }
        }else{

        }

        
    }
}
