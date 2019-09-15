using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBullet : MonoBehaviour
{
    public float verticalSpeed = 1.5f;

    public Material deadMaterial;
    private Rigidbody rb;
    private MeshRenderer renderer;

    private Health director;
    private bool dead = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        renderer = GetComponent<MeshRenderer>();
        rb.velocity = Vector3.down * verticalSpeed;
        director = GameObject.Find("SceneDirector").GetComponent<Health>();
    }


    void OnCollisionEnter(Collision other)
    {
        if (dead)
            return;
        dead = true;
        gameObject.tag = "Untagged";
        renderer.material = deadMaterial;
        rb.useGravity = true;
        rb.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionZ;

        
        if (other.gameObject.CompareTag("Player"))
        {
            director.KillPlayer();
            
            Destroy(gameObject);
           
        }
        if (other.gameObject.CompareTag("ShieldModules"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            
        }
       
    }
}
