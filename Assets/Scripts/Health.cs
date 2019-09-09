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
    public AudioSource deathSound;

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

        DeathStuff();
    }

    public void Die()
    {
        lives -= 1;

        DeathStuff();
    }

    private void DeathStuff()
    {
        livesText.text = lives + "";

        if (explosion != null)
        {
            //Debug.Log("death sound");
            deathSound.Play();
            Instantiate(explosion, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
    
}
