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
    public float armadaSpawnDelay;
    public float textAnimationDuration;

    private GameObject currentArmada;

    private int currentWaveNumber = 1;
    public Text waveDisplayText;
    private bool beingHandled = false;

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
            if(!beingHandled)
            StartCoroutine(SpawnNextArmada());
        }
    }
    private IEnumerator SpawnNextArmada()
    {
        beingHandled = true;
        yield return new WaitForSeconds(armadaSpawnDelay);
        Destroy(currentArmada);
        currentWaveNumber++;
        currentArmada = Instantiate(armadaPrefab, desiredArmadaPosition.position, Quaternion.identity);
        waveDisplayText.text = "Wave: " + currentWaveNumber;
        waveDisplayText.gameObject.SetActive(true);
        yield return new WaitForSeconds(textAnimationDuration);
        waveDisplayText.gameObject.SetActive(false);

       beingHandled = false;
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
