using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayDirector : MonoBehaviour
{   
    public ArmadaChildSpawner armadaPrefab;
    public Transform desiredArmadaPosition;
    public float armadaSpawnDelay;
    public float textAnimationDuration;

    public GameObject currentArmada;
    public AudioSource waveDestroyedSound;
    public AudioSource startSound;
    public Text waveDisplayText;

    public float startSoundDelay;

    public GameObject extraLifeMessage;

    private int currentWaveNumber = 1;
   
    //used for synchronization
    private bool beingHandled = false;

    private int wavesUntilLifeIncrease = 1;
    private int wavesLeftUntilLifeIncrease;
    private Health playerHealth;

    private int originalColumnCount;
    private int currentColumnCount;

    private void Start()
    {
        playerHealth = GetComponent<Health>();
        
        currentArmada = Instantiate(armadaPrefab.gameObject, desiredArmadaPosition.position, Quaternion.identity);
        StartCoroutine(PlayStartSound());

        wavesLeftUntilLifeIncrease = wavesUntilLifeIncrease;
        extraLifeMessage.SetActive(false);

        originalColumnCount = armadaPrefab.columns;
        currentColumnCount = originalColumnCount;
    }

    private void Update()
    {

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
        
        //give player extra life
        wavesLeftUntilLifeIncrease--;
        if(wavesLeftUntilLifeIncrease == 0)
        {
            wavesUntilLifeIncrease++;
            wavesLeftUntilLifeIncrease = wavesUntilLifeIncrease;
            playerHealth.IncreaseLives();

            extraLifeMessage.SetActive(true);
        }

        //destroys the current now empty armada object
        Destroy(currentArmada);

        //creates a new (possibly bigger/more columns armada)
        currentColumnCount = Mathf.Min(currentColumnCount + 1, armadaPrefab.columnLimit);
        armadaPrefab.columns = currentColumnCount;
        currentArmada = Instantiate(armadaPrefab.gameObject, desiredArmadaPosition.position, Quaternion.identity);
        armadaPrefab.columns = originalColumnCount;

        //displays wave info to player
        currentWaveNumber++;
        waveDisplayText.text = "Wave: " + currentWaveNumber;
        waveDisplayText.gameObject.SetActive(true);
        if (waveDestroyedSound != null)
            waveDestroyedSound.Play();

        yield return new WaitForSeconds(textAnimationDuration);
        waveDisplayText.gameObject.SetActive(false);
        extraLifeMessage.SetActive(false);

        beingHandled = false;
    }

    private IEnumerator PlayStartSound()
    {
     
        yield return new WaitForSeconds(startSoundDelay);
        startSound.Play();
    }

}
