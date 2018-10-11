using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is a script used to control the rotation of the eyelids
//Every time eyelids are clicked, they will close, and back to open after several seconds

//Remember to adjust the axis of the 3D model when changing the eyelid object
[RequireComponent(typeof(Animator))]
public class EyeInteraction : MonoBehaviour {

    public float maxOpenAngle = 40f;
    public float openLerpSpeed = 0.02f;
    public float closeAngleSpeed = 20f;
    public float angleDegLimit = 2f;

    private GameObject eyelidUp;
    private GameObject eyelidDown;
    private bool eyeClosed;
    private float waitForSeconds = 0;
    private bool open = false;
    private bool close = false;
    
    void Start ()
    {
        eyelidUp = this.transform.Find("EyelidlUp").gameObject;
        eyelidDown = this.transform.Find("EyelidlDown").gameObject;
        open = true;
    }

    void Update()
    {
        //This place can change if the range of the eyelids are changed
        if (close)
        {
            eyelidUp.transform.rotation = Quaternion.Euler(eyelidUp.transform.rotation.eulerAngles.x + (closeAngleSpeed * Time.deltaTime), eyelidUp.transform.rotation.eulerAngles.y, eyelidUp.transform.rotation.eulerAngles.z);
            eyelidDown.transform.rotation = Quaternion.Euler(eyelidDown.transform.rotation.eulerAngles.x - (closeAngleSpeed * Time.deltaTime), eyelidDown.transform.rotation.eulerAngles.y, eyelidDown.transform.rotation.eulerAngles.z);

            if (eyelidDown.transform.rotation.eulerAngles.x < angleDegLimit)
            {
                close = false;
                waitForSeconds = waitForSeconds + 0.5f;
                StartCoroutine(EyeOpenCountdownNew(waitForSeconds));
            }
        }
        else if (open)
        {
            float angle;
            angle = Mathf.Lerp(eyelidDown.transform.rotation.eulerAngles.x, maxOpenAngle, openLerpSpeed);
            eyelidUp.transform.rotation = Quaternion.Euler(-angle, eyelidUp.transform.rotation.eulerAngles.y, eyelidUp.transform.rotation.eulerAngles.z);
            eyelidDown.transform.rotation = Quaternion.Euler(angle, eyelidDown.transform.rotation.eulerAngles.y, eyelidDown.transform.rotation.eulerAngles.z);

            if ((maxOpenAngle - angle) % 360 < angleDegLimit)
            {
                open = false;
            }
        }

        eyeClosed = eyelidDown.transform.rotation.eulerAngles.x < angleDegLimit ? true : false;
    }

    //Call by player's input
    public void BeenClicked()
    {
        if (open)
        {
            return;
        }
        else
        {
            close = true;
        }
    }

    IEnumerator EyeOpenCountdownNew(float waitSeconds) //Next phase
    {
        yield return new WaitForSeconds(waitSeconds);
        open = true;
    }
}

[System.Serializable]
public struct CloseInfo
{
    public int clickCount;         //点击几次才能关闭
    public float nextOpenDelay;    //眼睛闭上后，下一次睁眼的延迟
}
