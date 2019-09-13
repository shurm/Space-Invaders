using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayDirector : MonoBehaviour
{
    public GameObject playerShip;
    public Text currentScore;
    public Text currentLivesAmount;

    private void Update()
    {
        int lives = int.Parse(currentLivesAmount.text);
        if (lives <= 0)
        {
            int score = int.Parse(currentScore.text);
            PlayerPrefs.SetInt("playerScore", score);
            GameObject.FindGameObjectWithTag("Armada").SetActive(false);
            SceneManager.LoadScene("HighScore");
        }
    }
    public void AfterShipExplosion()
    {
        int lives = int.Parse(currentLivesAmount.text);
        if (lives > 0)
        {
            playerShip.SetActive(true);
            return;
        }
    }
}
