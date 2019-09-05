using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
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
        rb.velocity = Vector3.up * verticalSpeed;
    }

    void OnBecameInvisible()
    {
        //Debug.Log("DESTROY!!");
        Destroy(gameObject);
    }
    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Alien"))
        {
            Transform aramada = other.transform.parent.parent;

            ArmadaAttackController armadaAttackController = aramada.GetComponent<ArmadaAttackController>();
            //Debug.Log("ttesting");
            armadaAttackController.GoFaster();

            if(other.transform.parent.childCount==1)
                Destroy(other.transform.parent);
            else
                Destroy(other.gameObject);
        }
        if (!other.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
