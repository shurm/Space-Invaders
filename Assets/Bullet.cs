﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float verticalSpeed = 1.5f;
    public string[] tags;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = Vector3.up * verticalSpeed;
    }

    void OnBecameInvisible()
    {
        //Debug.Log("DESTROY!!");
        Destroy(gameObject);
    }
    void OnTriggerEnter(Collider other)
    {

        //check if it hits enemy ship
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }
}