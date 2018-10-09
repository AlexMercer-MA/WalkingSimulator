using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeWallUnit : MonoBehaviour {

    public bool isFinished = false;
    public bool[] initialOpenStateArray;
    public int column;
    public int row;
    public Vector3 angle;
    GameObject[,] eyeObjectArray;
    EyeGameUnit[,] eyeGameUnitArray;

    public float distance = 0.2f;
    public GameObject eyeGameUnitPrefab;

    GameObject tempGameObject;

    void Awake () 
    {
        bool columnIsEven = (column % 2 == 0);
        bool rowIsEven = (row % 2 == 0);
        int halfColumn = column / 2;
        int halfRow = row / 2;
        eyeObjectArray = new GameObject[column,row];
        eyeGameUnitArray = new EyeGameUnit[column,row];

        //Create the eye game unit
        for (int i = 0; i < column; i++)
        {
            float xpos = columnIsEven ? (i - halfColumn + 0.5f) * distance : (i - halfColumn) * distance;
            for (int j = 0; j < row; j++)
            {
                float ypos = rowIsEven ? (j - halfRow + 0.5f) * distance : (j - halfRow) * distance;
                tempGameObject = Instantiate(eyeGameUnitPrefab, new Vector3(xpos,ypos,0f) + this.transform.position, Quaternion.identity, this.transform);
                eyeObjectArray[i,j] = tempGameObject;
                eyeGameUnitArray[i,j] = tempGameObject.GetComponent<EyeGameUnit>();
                bool initialState = initialOpenStateArray[i * column + j];
                eyeGameUnitArray[i,j].SetOpenState(initialState);
            }
        }

        //Set Near Eye of each eye
        for (int i = 0; i < column; i++)
        {
            for (int j = 0; j < row; j++)
            {
                if (i - 1 >= 0)
                {
                    eyeGameUnitArray[i, j].nearEyes.Add(eyeGameUnitArray[i - 1, j]);
                }
                if (i + 1 <= column - 1)
                {
                    eyeGameUnitArray[i, j].nearEyes.Add(eyeGameUnitArray[i + 1, j]);
                }
                if (j - 1 >= 0)
                {
                    eyeGameUnitArray[i, j].nearEyes.Add(eyeGameUnitArray[i, j - 1]);
                }
                if (j + 1 <= row - 1)
                {
                    eyeGameUnitArray[i, j].nearEyes.Add(eyeGameUnitArray[i, j + 1]);
                }
            }
        }

        //Can not rotate Issue
        this.transform.rotation = Quaternion.Euler(angle);

        //Check if it is already Finished
        CheckFinished();
    }
	
    public void CheckFinished () 
    {
		foreach (var eye in eyeGameUnitArray)
        {
            if (eye.IsOpen)
            {
                isFinished = false;
                return;
            }
        }
        //If not even one eye is open, then this wall is finished
        isFinished = true;
        return;
	}
}
