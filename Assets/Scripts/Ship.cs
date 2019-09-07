using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float DESIRED_SPEED = 5;

    public MeshRenderer baseRenderer;
    private Rigidbody rb;
    // Start is called before the first frame update

    private float halfPlayerSizeX;

    public GameObject bulletPrefab;

    public float intervalBetweenShots;

    public float bulletSpawnDistatnce;

    private float timeRemainingTillNextShot = 0;
    void Start()
    {
        halfPlayerSizeX = baseRenderer.bounds.size.x / 2;

        rb = GetComponent<Rigidbody>();

     
    }

    // Update is called once per frame
    void Update()
    {

        clampPlayerMovement();
        if (timeRemainingTillNextShot > 0)
            timeRemainingTillNextShot -= Time.deltaTime;

        if (Input.GetAxisRaw("Jump")>0 && timeRemainingTillNextShot<=0)
        {
            Instantiate(bulletPrefab, transform.position+Vector3.up*bulletSpawnDistatnce, Quaternion.identity);

            timeRemainingTillNextShot = intervalBetweenShots;
        }

    }

    private void FixedUpdate()
    {
        float current_speed = Input.GetAxisRaw("Horizontal") * DESIRED_SPEED;
        rb.velocity = Vector3.right* current_speed;
    }

    void clampPlayerMovement()
    {
        Vector3 position = transform.position;

        float distance = transform.position.z - Camera.main.transform.position.z;

        float leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance)).x + halfPlayerSizeX;
        float rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance)).x - halfPlayerSizeX;

        position.x = Mathf.Clamp(position.x, leftBorder, rightBorder);
        transform.position = position;
    }

}
