using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIfBelowY : MonoBehaviour
{
    private Transform bottomBoundary;

    private void Start()
    {
        bottomBoundary = GameObject.FindGameObjectWithTag("BottomBoundary").transform;
        if(bottomBoundary ==null)
        {
            Debug.Log("Error no bottom boundary found");
        }
    }
    void Update()
    {
        if (transform.position.y < bottomBoundary.position.y)
            Destroy(gameObject);
    }
}
