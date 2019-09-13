using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmadaController : MonoBehaviour
{

    public float movementTimeInterval;
    private float timeRemainingTillMove;

    public float horizonalDisplacement;

    public float verticalDisplacement;
    public int horizontalMoves;
    private int movesRemaining;

    public float attackTimeInterval;
    private float timeRemainingTillAttack;

    public GameObject bulletPrefab;
    public float bulletSpawnDistatnce;

    public float movementIntervalDifference = 0;

    // Start is called before the first frame update
    void Start()
    {
        timeRemainingTillMove = movementTimeInterval;
        movesRemaining = horizontalMoves;

        timeRemainingTillAttack = attackTimeInterval;
        
    }

    // Update is called once per frame
    void Update()
    {


        //movement logic 
        if (timeRemainingTillMove <= 0)
        {
            Vector3 displacement;
            if (movesRemaining <= 0)
            {
                displacement = Vector3.down * verticalDisplacement;
                movesRemaining = horizontalMoves;
                horizonalDisplacement *= -1;
            }
            else
            {
                displacement = Vector3.right * horizonalDisplacement;
                movesRemaining--;
            }
            for (int r = 0; r < transform.childCount; r++)
            {
                Transform row = transform.GetChild(r);
                for (int c = 0; c < row.childCount; c++)
                {
                    row.GetChild(c).position += displacement;
                    row.GetChild(c).gameObject.GetComponent<SpriteAnimation>().UpdateSprite();
                }
            }
            timeRemainingTillMove = movementTimeInterval;
        }
        else
        {
            timeRemainingTillMove -= Time.deltaTime;
        }


        //attack logic 
        if (timeRemainingTillAttack <= 0)
        {
            if (transform.childCount == 0)
                return;
            int randomAlienColumn = Random.Range(0, transform.childCount - 1);

            Transform columnChosen = transform.GetChild(randomAlienColumn);
            Transform lowestAlienInColumn = GetChildWithLowestY(columnChosen);

            Instantiate(bulletPrefab, lowestAlienInColumn.position + Vector3.down * bulletSpawnDistatnce, Quaternion.identity);

            timeRemainingTillAttack = attackTimeInterval;
        }
        else
        {
            timeRemainingTillAttack -= Time.deltaTime;
        }  
    }
    public void GoFaster()
    {
        movementTimeInterval -= movementIntervalDifference;
        attackTimeInterval -= movementIntervalDifference;
    }
    Transform GetChildWithLowestY(Transform column)
    {
        Transform lowestChild = column.GetChild(0);
        for (int i = 1; i < column.childCount; i++)
        {
            if (lowestChild.position.y > column.GetChild(1).position.y)
            {
                lowestChild = column.GetChild(1);
            }
        }
        return lowestChild;
    }

    
}
