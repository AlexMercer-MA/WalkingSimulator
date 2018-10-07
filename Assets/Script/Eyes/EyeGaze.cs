using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeGaze : MonoBehaviour {

    public float angleLimit = 30f;
    [HideInInspector]
    public GameObject target;
    [HideInInspector]
    public Transform targetTransform;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("MainCamera");
        targetTransform = target.transform;
    }

    void Update ()
    {
        this.transform.LookAt(targetTransform);
	}

    private void LateUpdate()
    {
        //TODO Limit The Turn Angle
        //Vector3 rotationAngle = this.transform.rotation.eulerAngles;
        //Debug.Log("x raw is" + rotationAngle.x % 180);
        //Debug.Log("y raw is" + rotationAngle.y % 180);
        //Debug.Log("z raw is" + rotationAngle.z % 180);
        //float x = Mathf.Clamp(rotationAngle.x % 180, -angleLimit, angleLimit);
        //float y = Mathf.Clamp(rotationAngle.y % 180, -angleLimit, angleLimit);
        //float z = Mathf.Clamp(rotationAngle.z % 180, -angleLimit, angleLimit);
        //this.transform.rotation = Quaternion.Euler(x, y, z);
    }
}
