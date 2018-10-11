using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlanetRotate : MonoBehaviour 
{
    private static PlanetRotate instance;
    public static PlanetRotate Instance
    {
        get
        {
            return instance;
        }
    }

    public float velocity = 1;
    private Rigidbody rb;

    void Awake () 
    {
        instance = this;
        rb = this.GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        this.transform.position = Vector3.zero;
    }

    public float rotateMoveSpeed;
    public float rotateTurnSpeed;

    public void RotatePlanet(float h, float v)
    {
        rb.AddTorque(-v * velocity, -h * velocity * 2, 0, ForceMode.Impulse);
        //transform.Rotate(-v * rotateMoveSpeed ,0f ,0f , Space.World);
        //transform.Rotate(0f, -h * rotateTurnSpeed, 0f, Space.World);
    }
}
