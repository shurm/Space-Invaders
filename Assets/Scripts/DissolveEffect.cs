using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveEffect : MonoBehaviour
{
    public float timeInterval = 2;
    private float timeRemaining;
    private Material dissolvingMaterial;

    private void Start()
    {
        dissolvingMaterial = GetComponent<Renderer>().material;
        timeRemaining = timeInterval;
    }

    private void Update()
    {
        Debug.Log(Mathf.Sin(Time.time) / 2 + 0.5f);
        timeRemaining -= Time.deltaTime;
        timeRemaining = Mathf.Max(0, timeRemaining);

        dissolvingMaterial.SetFloat("_DissolveAmount", (timeInterval - timeRemaining) / timeInterval);

        if (timeRemaining <= 0)
            Destroy(gameObject);
    }
}
