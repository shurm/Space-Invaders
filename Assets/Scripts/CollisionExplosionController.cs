using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CollisionExplosionController : MonoBehaviour
{
    public bool triggeredByOtherScript = false;
    public bool destroyOnCollision = true;
    public string [] objectsThatCauseThisToExplode;
    public string[] objectsThatWontMakeThisExplode;
    public GameObject explosionPrefab;
    public AudioSource explosionSound;
    private bool beingHandled = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (triggeredByOtherScript)
            return;
        if (objectsThatWontMakeThisExplode.Length > 0 && objectsThatWontMakeThisExplode.Contains(collision.gameObject.tag))
            return;
        
        if (objectsThatCauseThisToExplode.Length == 0 || objectsThatCauseThisToExplode.Contains(collision.gameObject.tag))
        {
            CreateExplosion();
            if (destroyOnCollision)
                Destroy(gameObject);
            else
                gameObject.SetActive(false);
        }
    }

    public void CreateExplosion()
    {
        if (beingHandled)
            return;
        beingHandled = true;
        if (explosionSound != null)
            explosionSound.Play();
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        beingHandled = false;
    }
}
