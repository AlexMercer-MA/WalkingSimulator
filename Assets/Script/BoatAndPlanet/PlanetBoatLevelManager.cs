using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBoatLevelManager : MonoBehaviour
{
    public float gameTimer;
    public EGameProcess gameProcess = EGameProcess.PREPARE;

    private static PlanetBoatLevelManager instance;
    public static PlanetBoatLevelManager Instance
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

    void Start ()
    {
        gameProcess = EGameProcess.PROCEED;
        StartCoroutine(LevelCountDown(gameTimer));
    }
	
    IEnumerator LevelCountDown(float timeCountDown)
    {
        yield return new WaitForSeconds(timeCountDown);
        gameProcess = EGameProcess.END;

        //TODO Do Something
    }
}
