using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    public float interactionDistance;
    public Camera cam;
    int layerMask;
    GameObject targetObject;

    void Awake()
    {
        cam = Camera.main;
        layerMask = LayerMask.GetMask("Interactive");
    }

    void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
            RaycastHit hit = new RaycastHit();

            if(Physics.Raycast(ray, out hit, interactionDistance, layerMask))
            {
                targetObject = hit.transform.gameObject;
            }

            if (targetObject)
            {
                PlayerIntetaction.Instance.LMB_Click(targetObject);
            }
        }
	}

}
