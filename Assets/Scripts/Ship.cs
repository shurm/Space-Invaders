using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float DESIRED_SPEED = 5;

   
    private Rigidbody rb;

    private float halfPlayerSizeX;

    public GameObject bulletPrefab;

    public float intervalBetweenShots;

    public float bulletSpawnDistatnce;

    private float timeRemainingTillNextShot = 0;

    private ScoreController scoreController;

    public AudioSource playerShotSound;

    public MeshRenderer baseRenderer;

    private float leftBorder, rightBorder;
    void Start()
    {
        halfPlayerSizeX = baseRenderer.bounds.size.x / 2;

        rb = GetComponent<Rigidbody>();

        scoreController = GetComponent<ScoreController>();

        float distance = transform.position.z - Camera.main.transform.position.z;

        leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance)).x + halfPlayerSizeX;
        rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance)).x - halfPlayerSizeX;

    }

    // Update is called once per frame
    void Update()
    {

        ClampPlayerMovement();
        if (timeRemainingTillNextShot > 0)
            timeRemainingTillNextShot -= Time.deltaTime;

        if (Input.GetAxisRaw("Jump")>0 && timeRemainingTillNextShot<=0)
        {
            playerShotSound.Play();
            GameObject newBullet = Instantiate(bulletPrefab, transform.position+Vector3.up*bulletSpawnDistatnce, Quaternion.identity);
            newBullet.GetComponent<PlayerBullet>().scoreController = scoreController;
            timeRemainingTillNextShot = intervalBetweenShots;
        }

    }

    private void FixedUpdate()
    {
        float current_speed = Input.GetAxisRaw("Horizontal") * DESIRED_SPEED;
        rb.velocity = Vector3.right* current_speed;
    }

    void ClampPlayerMovement()
    {
        Vector3 position = transform.position;

        position.x = Mathf.Clamp(position.x, leftBorder, rightBorder);
        transform.position = position;
    }

}
