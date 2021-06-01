using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoxes : MonoBehaviour
{
    public int xOffset;
    public int zOffset;
    public int columns;
    public int rows;
    public GameObject boxes;

    private void Start()
    {
        spawnBoxes();
    }
    void spawnBoxes()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                GameObject go = Instantiate(boxes,new Vector3(xOffset+i,0,zOffset+j),Quaternion.identity);
                GameManager.Get().totalBoxes++;
            }
        }
    }
}
