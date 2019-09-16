using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayDirector : MonoBehaviour
{
    public GameObject armadaPrefab;
    public Transform desiredArmadaPosition;
    public float armadaSpawnDelay;
    public float textAnimationDuration;

    public GameObject currentArmada;
    public AudioSource waveDestroyedSound;
    public AudioSource startSound;
    public Text waveDisplayText;

    public float startSoundDelay;

    private int currentWaveNumber = 1;
   
    private bool beingHandled = false;

    
    private void Start()
    {
        currentArmada = Instantiate(armadaPrefab, desiredArmadaPosition.position, Quaternion.identity);
        StartCoroutine(PlayStartSound());
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
        Destroy(currentArmada);
        currentWaveNumber++;
        currentArmada = Instantiate(armadaPrefab, desiredArmadaPosition.position, Quaternion.identity);
        waveDisplayText.text = "Wave: " + currentWaveNumber;
        waveDisplayText.gameObject.SetActive(true);
        if (waveDestroyedSound != null)
            waveDestroyedSound.Play();

        yield return new WaitForSeconds(textAnimationDuration);
        waveDisplayText.gameObject.SetActive(false);

       beingHandled = false;
    }

    private IEnumerator PlayStartSound()
    {
     
        yield return new WaitForSeconds(startSoundDelay);
        startSound.Play();
    }

}
