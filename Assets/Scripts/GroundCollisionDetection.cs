using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundCollisionDetection : MonoBehaviour
{
    public Health gamePlayDirector;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Alien"))
        {
            gamePlayDirector.DiePermanently();
        }
    }
}
