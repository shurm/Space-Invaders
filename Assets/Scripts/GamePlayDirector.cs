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

    private int currentWaveNumber = 1;
    public Text waveDisplayText;
    private bool beingHandled = false;

    
    private void Start()
    {
        currentArmada = Instantiate(armadaPrefab, desiredArmadaPosition.position, Quaternion.identity);
       
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
        yield return new WaitForSeconds(textAnimationDuration);
        waveDisplayText.gameObject.SetActive(false);

       beingHandled = false;
    }
    
}
