using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleParticleSystem : MonoBehaviour
{
    private ParticleSystem ps;
    public float sliderValue = 1.0F;
    public float parentSliderValue = 1.0F;
    public ParticleSystemScalingMode scaleMode;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        ParticleSystem.MainModule main = ps.main;
        main.scalingMode = scaleMode;
    }
}
