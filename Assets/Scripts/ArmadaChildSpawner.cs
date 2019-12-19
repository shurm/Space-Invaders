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

        float leftBoundaryX = -1 * columns / 2 * columnSpacing;
        if (columns % 2 == 0)
            leftBoundaryX += columnSpacing / 2;


        float leftBoundaryY = -1 * rows / 2 * rowSpacing;
        if (rows % 2 == 0)
            leftBoundaryY += rowSpacing / 2;

        Vector3 leftSpawnPos = new Vector3(leftBoundaryX, 0, 0);

        Vector3 bottomSpawnPos = new Vector3(0, leftBoundaryY, 0);


        for (int c = 0; c < columns; c++)
        {
            Vector3 pos = transform.position + leftSpawnPos + Vector3.right * columnSpacing * c;

            GameObject newColumn = GameObject.Instantiate(emptyColumn, pos, Quaternion.identity, transform);

            for (int r = 0; r < alienPrefabs.Length; r++)
            {
                for (int d = 0; d < duplicateRows; d++)
                {
                    pos = transform.position + leftSpawnPos + Vector3.right * columnSpacing * c + bottomSpawnPos + Vector3.up * rowSpacing * (duplicateRows * r + d);
                    Instantiate(alienPrefabs[alienPrefabs.Length - 1 - r], pos, Quaternion.identity, newColumn.transform);
                }
            }
        }

        Destroy(emptyColumn);

    }

}
