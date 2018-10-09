using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeGameUnit : MonoBehaviour {

    public bool IsOpen;
    public GameObject eyelidUp;
    public GameObject eyelidDown;
    public float maxOpenAngle = 40f;
    public List<EyeGameUnit> nearEyes = new List<EyeGameUnit>();
    public EyeWallUnit eyeWallUnit;

    void Awake () 
    {
        eyelidUp = this.transform.Find("EyelidlUp").gameObject;
        eyelidDown = this.transform.Find("EyelidlDown").gameObject;
        eyeWallUnit = this.GetComponentInParent<EyeWallUnit>();

        if (IsOpen)
        {
            OpenAction();
        }
        else
        {
            CloseAction();
        }
	}
	
    public void BeenClicked()
    {
        if (eyeWallUnit.isFinished)
        {
            return;
        }
        SetOppositeOpenState();
        foreach (EyeGameUnit eye in nearEyes)
        {
            eye.SetOppositeOpenState();
        }
        eyeWallUnit.CheckFinished();
    }

    public void SetOpenState(bool state)
    {
        IsOpen = state;
        if (IsOpen)
        {
            OpenAction();
        }
        else
        {
            CloseAction();
        }
    }

    public void SetOppositeOpenState()
    {
        SetOpenState(!IsOpen);
    }

    public void OpenAction()
    {
        eyelidUp.transform.localRotation = Quaternion.Euler(-maxOpenAngle, 180 - this.transform.rotation.y, this.transform.rotation.z);
        eyelidDown.transform.localRotation = Quaternion.Euler(maxOpenAngle, 180 + this.transform.rotation.y, this.transform.rotation.z);
    }

    public void CloseAction()
    {
        eyelidUp.transform.localRotation = Quaternion.Euler(0, 180 - this.transform.rotation.y, this.transform.rotation.z);
        eyelidDown.transform.localRotation = Quaternion.Euler(0, 180 - this.transform.rotation.y, this.transform.rotation.z);
    }
    
}
