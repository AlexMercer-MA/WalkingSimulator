using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeGameAndCoridorGameManager : MonoBehaviour {

    private static EyeGameAndCoridorGameManager instance;
    public static EyeGameAndCoridorGameManager Instance
    {
        get
        {
            return instance;
        }
    }

    public EEyeGameAndCoridorGameProcess gameProcess = EEyeGameAndCoridorGameProcess.PREPARE;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {

    }
}

public enum EEyeGameAndCoridorGameProcess
{
    PREPARE,
    STAGE_EYEGAME,      //Stage1
    STAGE_CORIDOR,      //Stage2
    STAGE_LIGHTCHASE,   //Stage3
    END,
}
