using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EyeInteraction : MonoBehaviour {

    public CloseInfo[] phaseInfo;
    public GameObject eyelidUp;
    public GameObject eyelidDown;
    public float maxOpenAngle = 40f;

    int phase = 0;
    int clickedCount = 0;
    int requireCount = 0;
    
    void Start ()
    {
        PhaseStart(0);
        eyelidUp = this.transform.Find("EyelidlUp").gameObject;
        eyelidDown = this.transform.Find("EyelidlDown").gameObject;
    }

    //Call by player's input
    public void BeenClicked()
    {
        clickedCount++;
        if (clickedCount >= requireCount)
        {
            CloseAction();
        }
    }

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
