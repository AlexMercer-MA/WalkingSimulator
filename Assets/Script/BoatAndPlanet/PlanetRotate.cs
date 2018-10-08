using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Awake () 
    {
        instance = this;
    }
    
    public float rotateMoveSpeed;
    public float rotateTurnSpeed;

    public void RotatePlanet(float h, float v)
    {
        transform.Rotate(-v * rotateMoveSpeed ,0f ,0f , Space.World);
        transform.Rotate(0f, -h * rotateTurnSpeed, 0f, Space.World);
    }
}
