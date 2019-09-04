using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmadaMovementController : MonoBehaviour
{
    public float movementTimeInterval;
    private float timeRemaining;

    public float horizonalDisplacement;

    public float verticalDisplacement;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = movementTimeInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining <= 0)
        {
            for (int r = 0; r < transform.childCount; r++)
            {
                Transform row = transform.GetChild(r);
                for (int c = 0; c < row.childCount; c++)
                {
                    row.GetChild(c).position += Vector3.right * horizonalDisplacement;
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
