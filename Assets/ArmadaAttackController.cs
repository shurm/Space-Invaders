﻿using System.Collections;
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
            int randomAlienColumn = Random.Range(0, transform.childCount-1);

            Transform columnChosen = transform.GetChild(randomAlienColumn);
            Transform lowestAlienInColumn = GetChildWithLowestY(columnChosen);

            Instantiate(bulletPrefab, lowestAlienInColumn.position + Vector3.down * bulletSpawnDistatnce, Quaternion.identity);

            timeRemaining = attackTimeInterval;
        }
        else
        {
            timeRemaining -= Time.deltaTime;
        }
    }
    Transform GetChildWithLowestY(Transform column)
    {
        Transform lowestChild = column.GetChild(0);
        for(int i=1;i<column.childCount;i++)
        {
            if(lowestChild.position.y > column.GetChild(1).position.y)
            {
                lowestChild = column.GetChild(1);
            }
        }
        return lowestChild;
    }
}
