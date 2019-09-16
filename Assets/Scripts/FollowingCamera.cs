using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    public Transform newParent;
    private Vector3 difference; 
    void Start()
    {
        difference = transform.position - player.position;

        transform.parent = newParent;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.gameObject.activeSelf)
            transform.position = difference + player.position;
    }
}
