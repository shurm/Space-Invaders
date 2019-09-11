using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBullet : MonoBehaviour
{
    public float verticalSpeed = 1.5f;

    public Material deadMaterial;
    private Rigidbody rb;
    private MeshRenderer renderer;
    private bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        renderer = GetComponent<MeshRenderer>();
    }
    void Update()
    {
        if(transform.position.y<-1)
            Destroy(gameObject);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(!dead)
            rb.velocity = Vector3.down * verticalSpeed;
        
    }

    
    void OnCollisionEnter(Collision other)
    {
        if (dead)
            return;
        //Debug.Log("collided with "+other.gameObject.tag);
        if (other.gameObject.CompareTag("Dead") || other.gameObject.CompareTag("Ground"))
        {
            dead = true;
            gameObject.tag = "Dead";
            renderer.material = deadMaterial;
            rb.useGravity = true;
            rb.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionZ; ;
            return;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            Transform partOfShip = other.transform;
            Health health = partOfShip.GetComponentInParent<Health>();
            health.Die();
        }
        else if (other.gameObject.CompareTag("ShieldModules"))
        {
            Destroy(other.gameObject);
        }
        if (!other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
