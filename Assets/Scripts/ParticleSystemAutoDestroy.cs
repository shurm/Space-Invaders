using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ParticleSystemAutoDestroy : MonoBehaviour
{
    private ParticleSystem ps;
    private Health director;
    public bool notifyDirector = true;
    public void Start()
    {
        director = GameObject.Find("SceneDirector").GetComponent <Health>();
        ps = GetComponent<ParticleSystem>();
    }

    public void Update()
    {
        if (ps)
        {
            if (!ps.IsAlive())
            {
                if(notifyDirector)
                    director.AfterShipExplosion();
                Destroy(gameObject);
            }
        }
    }
}
