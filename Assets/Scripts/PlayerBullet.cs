using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float verticalSpeed = 1.5f;

    public ScoreController scoreController;

    

    public GameObject explosion;


    private AudioSource deathSound;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        deathSound = GetComponent<AudioSource>();
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
            PointsEarnedWhenDestroyed p = other.gameObject.GetComponent<PointsEarnedWhenDestroyed>();
            Transform aramada = other.transform.parent.parent;

            ArmadaController armadaAttackController = aramada.GetComponent<ArmadaController>();
           // Debug.Log("ttesting");
            armadaAttackController.GoFaster();

            if(other.transform.parent.childCount==1)
                Destroy(other.transform.parent.gameObject);
            else
                Destroy(other.gameObject);

            scoreController.UpdateScore(p.points);

            //deathSound.Play();
            if (explosion!=null)
                Instantiate(explosion, other.transform.position, Quaternion.identity);
        }
        if (!other.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
