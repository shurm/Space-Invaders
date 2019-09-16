using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienColliderScript : MonoBehaviour
{
    public Material deadMaterial;
    public Sprite deadSprite;
    private Rigidbody rigidbody;
    private MeshRenderer[] renderers;
    private SpriteRenderer spriteRenderer;
    private float lowerYBound = 0.5f;

    private Health healthController;
    private PointsEarnedWhenDestroyed p;
    private ScoreController scoreController;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        renderers = GetComponentsInChildren<MeshRenderer>();
        GameObject director = GameObject.Find("SceneDirector");
        healthController = director.GetComponent<Health>();
        scoreController = director.GetComponent<ScoreController>();
        p = GetComponent<PointsEarnedWhenDestroyed>();
    }
    private void Update()
    {
        //if dead
        if (transform.parent == null)
            return;

        if (transform.position.y < lowerYBound)
        {
            healthController.EndGame();
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        //if dead
        if (transform.parent == null)
            return;

        if (other.gameObject.CompareTag("PlayerBullet"))
        {

            Die();
            other.gameObject.tag = "Untagged";
        }

        if (other.gameObject.CompareTag("ShieldModules"))
        {
            ShieldController shieldController = other.gameObject.GetComponentInParent<ShieldController>();
            if(shieldController!=null)
                shieldController.DestroyShield();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if dead
        if (transform.parent == null)
            return;
        if (other.gameObject.CompareTag("MissileExplosion"))
        {
            Die();
        }
    }

    private void Die()
    {
        Transform aramada = transform.parent.parent;
        //ArmadaController armadaAttackController = aramada.GetComponent<ArmadaController>();

        //armadaAttackController.GoFaster();

        scoreController.UpdateScore(p.points);

        Transform column = transform.parent;
        transform.parent = null;
        rigidbody.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionZ;

        if (column.childCount == 0)
            Destroy(column.gameObject);

        foreach (MeshRenderer renderer in renderers)
        {
            renderer.material = deadMaterial;
        }
        spriteRenderer.sprite = deadSprite;
    }
}
