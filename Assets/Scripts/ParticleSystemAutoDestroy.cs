using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ParticleSystemAutoDestroy : MonoBehaviour
{
    private ParticleSystem ps;
    public GamePlayDirector director;

    public void Start()
    {
        director = GameObject.Find("SceneDirector").GetComponent<GamePlayDirector>();
        ps = GetComponent<ParticleSystem>();
    }

    public void Update()
    {
        if (ps)
        {
            if (!ps.IsAlive())
            {
                director.AfterShipExplosion();
                Destroy(gameObject);
            }
        }
    }
}
