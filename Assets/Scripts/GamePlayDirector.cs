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
    public GameObject armadaPrefab;
    public Transform desiredArmadaPosition;
    private GameObject currentArmada;

    private void Start()
    {
        currentArmada = Instantiate(armadaPrefab, desiredArmadaPosition.position, Quaternion.identity);
    }

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
        if (currentArmada.transform.childCount == 0)
        {
            Destroy(currentArmada);
            currentArmada = Instantiate(armadaPrefab, desiredArmadaPosition.position, Quaternion.identity);
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
