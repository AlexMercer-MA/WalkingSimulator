using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorDoor : MonoBehaviour {

    Animator animator;
    Collider doorCloseTriggerArea;
    bool hasBeenClosed = false;

    void Awake()
    {
        animator = this.GetComponent<Animator>();
    }

    void OpenDoor()
    {
        if (hasBeenClosed)
        {
            return;
        }
        animator.SetTrigger("Open");
    }

    //If the player walks into the trigger area, then close the door permanently
    public void CloseDoor()
    {
        hasBeenClosed = true;
        animator.SetTrigger("Close");
    }
}
