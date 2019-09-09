using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int lives;
    public GameObject explosion;


    private Text livesText;
    private GameObject armada;
 
    private void Start()
    {
        livesText = GameObject.Find("Lives Number").GetComponent<Text>();
        armada = GameObject.Find("Armada");
    }

    public void DiePermanently()
    {
        lives = 0;

        livesText.text = lives + "";

        if (explosion != null)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }

    public void Die()
    {
        lives -= 1;

        livesText.text = lives + "";

        if (explosion != null)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }

        
    }

    
}
