using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIfBelowY : MonoBehaviour
{
    public float bottomY = -1;

    void Update()
    {
        if (transform.position.y < bottomY)
            Destroy(gameObject);
    }
}
