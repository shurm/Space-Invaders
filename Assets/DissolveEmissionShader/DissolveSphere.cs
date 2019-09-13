using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveSphere : MonoBehaviour {

    public float timeInterval = 2;
    private float timeRemaining;
    private Material disolvingMaterial;

    private void Start() {
        disolvingMaterial = GetComponent<Renderer>().material;
        timeRemaining = timeInterval;
    }

    private void Update() {
        Debug.Log(Mathf.Sin(Time.time) / 2 + 0.5f);
        timeRemaining -= Time.deltaTime;
        timeRemaining = Mathf.Max(0, timeRemaining);
        disolvingMaterial.SetFloat("_DissolveAmount", (timeInterval-timeRemaining) / timeInterval);
    }
}