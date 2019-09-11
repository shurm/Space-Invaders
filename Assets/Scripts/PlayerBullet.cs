using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float initialVerticalSpeed = 8f;

    public ScoreController scoreController;

    public GameObject explosion;


    private AudioSource deathSound;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        deathSound = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.up * initialVerticalSpeed;
    }

    void Update()
    {
        if(transform.position.y<0)
            Destroy(gameObject);
    }
    void OnCollisionEnter(Collision other)
    {
       
        if (other.gameObject.CompareTag("Alien"))
        {
            PointsEarnedWhenDestroyed p = other.gameObject.GetComponent<PointsEarnedWhenDestroyed>();

            scoreController.UpdateScore(p.points);

            //deathSound.Play();
            if (explosion!=null)
                Instantiate(explosion, other.transform.position, Quaternion.identity);
        }
        if (!other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
