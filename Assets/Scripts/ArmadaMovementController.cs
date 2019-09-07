using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmadaMovementController : MonoBehaviour
{
    public float movementTimeInterval;
    private float timeRemaining;

    public float horizonalDisplacement;

    public float verticalDisplacement;
    public int horizontalMoves;
    private int movesRemaining;
    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = movementTimeInterval;
        movesRemaining = horizontalMoves;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining <= 0)
        {
            Vector3 displacement;
            if (movesRemaining <= 0)
            {
                displacement = Vector3.down * verticalDisplacement;
                movesRemaining = horizontalMoves;
                horizonalDisplacement *= -1;
            }
            else
            {
                displacement = Vector3.right * horizonalDisplacement;
                movesRemaining--;
            }
            for (int r = 0; r < transform.childCount; r++)
            {
                Transform row = transform.GetChild(r);
                for (int c = 0; c < row.childCount; c++)
                {
                    row.GetChild(c).position += displacement;
                   
                }
            }
            timeRemaining = movementTimeInterval;
        }
        else
        {
            timeRemaining -= Time.deltaTime;
        }
    }
}
