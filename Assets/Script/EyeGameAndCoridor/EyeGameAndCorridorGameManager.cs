using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeGameAndCorridorGameManager : MonoBehaviour {

    private static EyeGameAndCorridorGameManager instance;
    public static EyeGameAndCorridorGameManager Instance
    {
        get
        {
            return instance;
        }
    }

    public EEyeGameAndCorridorGameProcess gameProcess;
    int wallFinished = 0;

    void Awake()
    {
        instance = this;
        gameProcess = EEyeGameAndCorridorGameProcess.PREPARE;
    }

    void SetWallFinished()
    {
        wallFinished++;
    }

    void CheckEyeGameFinished()
    {
        if (wallFinished >= 3)
        {
            gameProcess = EEyeGameAndCorridorGameProcess.STAGE_CORRIDOR;
            InitializeStageCorridor();
        }
    }

    void InitializeStageCorridor()
    {
        //Open the door

        //Set People without eyes and the walking audios

    }

}

public enum EEyeGameAndCorridorGameProcess
{
    PREPARE,
    STAGE_EYEGAME,      //Stage1
    STAGE_CORRIDOR,      //Stage2
    STAGE_LIGHTCHASE,   //Stage3
    END,
}
