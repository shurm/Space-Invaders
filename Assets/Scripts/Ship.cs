using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    public float sideToSideMovementSpeed = 5;

    public Text missileShotsDisplayText;
    public int missileShotsRemaining;
    private Rigidbody rb;

    private float halfPlayerSizeX;

    public GameObject bulletPrefab;
    public GameObject rocketPrefab;

    public float intervalBetweenShots;

    public float bulletSpawnDistatnce;

    private float timeRemainingTillNextShot = 0;

    private ScoreController scoreController;

    public AudioSource playerShotSound;

    public MeshRenderer baseRenderer;

    private float leftBorder, rightBorder;

    private Joystick joystick;

    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        halfPlayerSizeX = baseRenderer.bounds.size.x / 2;

        rb = GetComponent<Rigidbody>();

        scoreController = GetComponent<ScoreController>();

        float distance = transform.position.z - Camera.main.transform.position.z;

        leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance)).x + halfPlayerSizeX;
        rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance)).x - halfPlayerSizeX;

        missileShotsDisplayText.text = "" + missileShotsRemaining;
    }

    // Update is called once per frame
    void Update()
    {

        ClampPlayerMovement();
        if (timeRemainingTillNextShot > 0)
            timeRemainingTillNextShot -= Time.deltaTime;

        if (Input.GetAxisRaw("Jump")>0 )
        {
            LaunchBullet();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            LaunchMissile();
        }

    }

    public void LaunchBullet()
    {
        if (timeRemainingTillNextShot <= 0)
        { 
            playerShotSound.Play();
            GameObject newBullet = Instantiate(bulletPrefab, transform.position + Vector3.up * bulletSpawnDistatnce, Quaternion.identity);
            timeRemainingTillNextShot = intervalBetweenShots;
        }
    }
    public void LaunchMissile()
    {
        if( timeRemainingTillNextShot <= 0 && missileShotsRemaining > 0)
        {
            GameObject newRocket = Instantiate(rocketPrefab, rocketPrefab.transform.position, Quaternion.identity);
            newRocket.SetActive(true);
            timeRemainingTillNextShot = intervalBetweenShots;

            missileShotsRemaining--;

            missileShotsDisplayText.text = "" + missileShotsRemaining;
        }
    }
    public float GetPlayerSizeX()
    {
        return halfPlayerSizeX;
    }

    private void FixedUpdate()
    {
        float current_speed = Input.GetAxisRaw("Horizontal") * sideToSideMovementSpeed;
        if (joystick != null)
            current_speed += joystick.Horizontal * sideToSideMovementSpeed;
        rb.velocity = Vector3.right* current_speed;
    }

    void ClampPlayerMovement()
    {
        Vector3 position = transform.position;

        position.x = Mathf.Clamp(position.x, leftBorder, rightBorder);
        transform.position = position;
    }

}
