using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmadaAttackController : MonoBehaviour
{
    public float attackTimeInterval;
    private float timeRemaining;

    public GameObject bulletPrefab;
    public float bulletSpawnDistatnce;
    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = attackTimeInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining <= 0)
        {
            
            timeRemaining = attackTimeInterval;
        }
        else
        {
            timeRemaining -= Time.deltaTime;
        }
    }
}
