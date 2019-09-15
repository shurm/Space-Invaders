using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int lives;
    private Text livesText;

    private ScoreController scoreController;
    private GamePlayDirector director;

    public GameObject player;
    private void Start()
    {
        livesText = GameObject.Find("Lives Number").GetComponent<Text>();
        scoreController = GetComponent<ScoreController>();
        director = GetComponent<GamePlayDirector>();
    }
    
    internal void KillPlayer()
    {
        lives--;
        KillPlayerHelper();
    }
    internal void EndGame()
    {
        lives = 0;
        KillPlayerHelper();
    }

    private void KillPlayerHelper()
    {
        livesText.text = lives + "";
        
        player.GetComponent<CollisionExplosionController>().CreateExplosion();
        player.SetActive(false);
    }

   
    public void AfterShipExplosion()
    {
        
        if (lives > 0)
        {
            player.SetActive(true);
            return;
        }
        
        if (lives <= 0)
        {
            int score = scoreController.currentScore;
            PlayerPrefs.SetInt("playerScore", score);
            director.currentArmada.SetActive(false);
            SceneManager.LoadScene("HighScore");
        }
    }

}
