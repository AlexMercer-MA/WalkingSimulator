using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlManager : MonoBehaviour {

    private static GameControlManager instance;
    public static GameControlManager Instance
    {
        get
        {
            return instance;
        }
    }

    protected virtual void Awake()
    {
        instance = this;
    }
}

public enum EGameProcess
{
    PREPARE,
    PROCEED,
    END,
}
