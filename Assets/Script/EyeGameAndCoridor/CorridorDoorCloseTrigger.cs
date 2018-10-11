using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorDoorCloseTrigger : MonoBehaviour 
{
    CorridorDoor corridorDoor;

    void Awake()
    {
        corridorDoor = this.GetComponentInParent<CorridorDoor>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            corridorDoor.CloseDoor();
        }
    }
}
