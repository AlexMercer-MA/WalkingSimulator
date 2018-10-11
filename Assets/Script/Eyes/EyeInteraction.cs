using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is a script used to control the rotation of the eyelids
//Every time eyelids are clicked, they will close, and back to open after several seconds

//Remember to adjust the axis of the 3D model when changing the eyelid object
[RequireComponent(typeof(Animator))]
public class EyeInteraction : MonoBehaviour {

    //public CloseInfo[] phaseInfo;
    public GameObject eyelidUp;
    public GameObject eyelidDown;
    public float maxOpenAngle = 40f;
    public float openSpeed;
    public float closeSpeed;
    public bool eyeClosed;
    private float waitForSeconds=0;

   // int phase = 0;
    int clickedCount = 0;
    int requireCount = 0;
    private bool open = false;
    private bool close = false;
    
    void Start ()
    {
        //PhaseStart(0);
        eyelidUp = this.transform.Find("EyelidlUp").gameObject;
        eyelidDown = this.transform.Find("EyelidlDown").gameObject;
    }

    void Update()
    {
        //This place can change if the range of the eyelids are changed
        if (close)
        {
            eyelidUp.transform.rotation = Quaternion.Euler(this.transform.rotation.x + (closeSpeed * Time.deltaTime), 180 - this.transform.rotation.y, this.transform.rotation.z);
            eyelidDown.transform.rotation = Quaternion.Euler(this.transform.rotation.x - (closeSpeed * Time.deltaTime), 180 - this.transform.rotation.y, this.transform.rotation.z);
            Debug.Log(closeSpeed * Time.deltaTime );
            if ( eyelidDown.transform.rotation.x< 2)
            {
                close = false;
                waitForSeconds = waitForSeconds + 0.5f;
            }
        }
        else
        {
            /*if (open)
            {
                float a;
                a = Mathf.Lerp(eyelidDown.transform.rotation.x, maxOpenAngle, openSpeed);
                eyelidUp.transform.rotation = Quaternion.Euler(-a, 180 - this.transform.rotation.y, this.transform.rotation.z);
                eyelidDown.transform.rotation = Quaternion.Euler(a, 180 - this.transform.rotation.y, this.transform.rotation.z);
                if (maxOpenAngle - a < 2)
                {
                    open = false;
                }
            }
            */
        }

        if (eyelidDown.transform.rotation.x < 2)
        {
            eyeClosed = true;
        }
        else
        {
            eyeClosed = false;
        }
    }

    //Call by player's input
    public void BeenClicked()
    {
        //CloseAction();
        close = true;
        StartCoroutine(EyeOpenCountdownNew(waitForSeconds));
    }

    /*
    public void CloseAction()
    {
        eyelidUp.transform.rotation = Quaternion.Euler(0, 180 - this.transform.rotation.y, this.transform.rotation.z);
        eyelidDown.transform.rotation = Quaternion.Euler(0, 180 - this.transform.rotation.y, this.transform.rotation.z);
        if (phase < phaseInfo.Length - 1)
        {
            phase++;
            PhaseStart(phase);
        }
        else
        {
            //TODO SCENE OVER
            //TODO SCENE OVER
            //TODO SCENE OVER
            //GameManager LevelProgress++；
        }
    }
    
    //Call when a new phase is start
    void PhaseStart(int newPhaseCount)
    {
        if (newPhaseCount > phaseInfo.Length - 1)
        {
            throw new Exception("Eye Close Phase is over limit");
        }
        phase = newPhaseCount;
        clickedCount = 0;
        requireCount = phaseInfo[newPhaseCount].clickCount;

        StartCoroutine(EyeOpenCountdown(newPhaseCount));
    }
    
    IEnumerator EyeOpenCountdown(int phaseCount) //Next phase count
    {
        if (phaseCount > phaseInfo.Length - 1)
        {
            throw new Exception("Eye Close Phase is over limit");
        }
        yield return new WaitForSeconds(phaseInfo[phaseCount].nextOpenDelay);
        OpenAction(phaseCount);
    }*/
    
        IEnumerator EyeOpenCountdownNew(float waitSeconds) //Next phase count
    {
        /*if (phaseCount > phaseInfo.Length - 1)
        {
            throw new Exception("Eye Close Phase is over limit");
        }
        */
        yield return new WaitForSeconds(waitSeconds);
        open = true;
    }
    
    void OpenAction(int phaseCount)
    {
        eyelidUp.transform.rotation = Quaternion.Euler(-maxOpenAngle, 180 - this.transform.rotation.y, this.transform.rotation.z);
        eyelidDown.transform.rotation = Quaternion.Euler(maxOpenAngle, 180 + this.transform.rotation.y, this.transform.rotation.z);
        
    }
}

[System.Serializable]
public struct CloseInfo
{
    public int clickCount;         //点击几次才能关闭
    public float nextOpenDelay;    //眼睛闭上后，下一次睁眼的延迟
}
