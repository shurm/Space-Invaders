using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    public float verticalSpeed;
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();   
    }
    private void Update()
    {
        rb.velocity = Vector3.up * verticalSpeed;
    }
}
