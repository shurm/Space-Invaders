using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmadaChildSpawner : MonoBehaviour
{
    public GameObject[] alienPrefabs;

    public float rowSpacing;
    public float columnSpacing;

    public int columns;

    public int rows;
    // Start is called before the first frame update
    void Start()
    {
        int duplicateRows = rows / alienPrefabs.Length;
        GameObject emptyColumn = new GameObject("column");

        float leftBoundary = -1 * columns / 2 * columnSpacing;
        if (columns % 2 == 1)
            leftBoundary -= columnSpacing / 2;

        Vector3 leftSpawnPos = new Vector3(leftBoundary, 0, 0);

        for (int c = 0;c<columns;c++)
        {
            GameObject newColumn = GameObject.Instantiate(emptyColumn, Vector3.zero, Quaternion.identity, transform);
            newColumn.transform.localPosition = leftSpawnPos + Vector3.right * columnSpacing*c;


        }

        Destroy(emptyColumn);

    }

   
}
