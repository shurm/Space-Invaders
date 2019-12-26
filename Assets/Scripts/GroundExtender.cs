using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//stretches or shrinks the ground so that it scales to the screen size
public class GroundExtender : MonoBehaviour
{
    private float leftBorder, rightBorder;


    void Start()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Ship player = FindObjectOfType<Ship>();

        leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance)).x + player.GetPlayerSizeX()*3/4;
        rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance)).x - player.GetPlayerSizeX()*3/4;

        Vector3 centerPos = new Vector3(leftBorder + rightBorder, transform.position.y) / 2;

        float scaleX = Mathf.Abs(rightBorder - leftBorder);
        //float scaleY = Mathf.Abs(startPos.y - endPos.y);

        centerPos.x -= 0.5f;
       
       // transform.position = centerPos;
        transform.localScale = new Vector3(scaleX, transform.localScale.y, 1);
    }

    public float GetLeftBorder()
    {
        return leftBorder;
    }
    public float GetRightBorder()
    {
        return rightBorder;
    }
}
