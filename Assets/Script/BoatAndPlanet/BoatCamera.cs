using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatCamera : MonoBehaviour {

    public Camera cam;
    public float mouseX;
    public float mouseY;

    void Start () 
    {
        cam = Camera.main;
	}
	
	void Update () 
    {
        if (PlanetBoatLevelManager.Instance.gameProcess == EGameProcess.PROCEED)
        {
            mouseX = Input.GetAxis("Mouse X");
            mouseY = Input.GetAxis("Mouse Y");
            cam.transform.Rotate(-mouseY, 0, 0, Space.Self);
            cam.transform.Rotate(0, mouseX, 0, Space.World);
        }
    }
}
