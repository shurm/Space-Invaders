﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBullet : MonoBehaviour
{
    public float verticalSpeed = 1.5f;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = Vector3.down * verticalSpeed;
    }

    void OnBecameInvisible()
    {
        //Debug.Log("DESTROY!!");
        Destroy(gameObject);
    }
    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            Transform partOfShip = other.transform;
            Health health = partOfShip.GetComponentInParent<Health>();
            health.Die();
        }
        else if (other.CompareTag("ShieldModules"))
        {
            Destroy(other.gameObject);
        }
        if (!other.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
