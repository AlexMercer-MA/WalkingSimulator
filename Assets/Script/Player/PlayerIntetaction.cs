using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIntetaction : MonoBehaviour
{
    private static PlayerIntetaction instance;
    public static PlayerIntetaction Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        instance = this;
    }
    
    public void LMB_Click(GameObject targetObject)
    {
        switch (targetObject.tag)
        {
            case "Eye":
                targetObject.GetComponent<EyeInteraction>().BeenClicked();
                break;
            case "EyeGame":
                targetObject.GetComponent<EyeGameUnit>().BeenClicked();
                break;
            default:
                break;
        }
    }
}
