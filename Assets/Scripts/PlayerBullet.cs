﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float initialVerticalSpeed = 8f;
    
    public ScoreController scoreController;

    public GameObject explosion;

    public Material deadMaterial;
    
    private MeshRenderer renderer;
  
    private AudioSource deathSound;
    private Rigidbody rb;

    private bool dead = false;


    // Start is called before the first frame update
    void Start()
    {
        deathSound = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.up * initialVerticalSpeed;
        renderer = GetComponent<MeshRenderer>();
    }


    
    void OnCollisionEnter(Collision other)
    {
        if (dead)
            return;
        dead = true;
        renderer.material = deadMaterial;
        
        rb.useGravity = true;
        rb.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionZ;
        if (other.gameObject.CompareTag("Alien"))
        {
            PointsEarnedWhenDestroyed p = other.gameObject.GetComponent<PointsEarnedWhenDestroyed>();

            scoreController.UpdateScore(p.points);

            //deathSound.Play();
            if (explosion != null)
                Instantiate(explosion, other.transform.position, Quaternion.identity);
        }
        else
            tag = "Untagged";

    }
}
