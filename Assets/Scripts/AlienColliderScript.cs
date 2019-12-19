using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienColliderScript : MonoBehaviour
{
    public Material deadMaterial;
    private SpriteAnimation spriteAnimation;
    private Rigidbody rigidbody;

    private float minDistanceToGround = 1f;

    private Health healthController;
    private PointsEarnedWhenDestroyed p;
    private ScoreController scoreController;
    private GameObject ground;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        spriteAnimation = GetComponent<SpriteAnimation>();
       
        GameObject director = GameObject.Find("SceneDirector");
        healthController = director.GetComponent<Health>();
        scoreController = director.GetComponent<ScoreController>();
        p = GetComponent<PointsEarnedWhenDestroyed>();
        ground = GameObject.Find("Ground");
    }
    private void Update()
    {
        //if dead
        if (transform.parent == null)
            return;

        if ((transform.position.y- ground.transform.position.y)<= minDistanceToGround)
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

        if (scoreController == null)
            Start();
        scoreController.UpdateScore(p.points);

        Transform column = transform.parent;
        transform.parent = null;
        rigidbody.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionZ;

        if (column.childCount == 0)
            Destroy(column.gameObject);

        foreach (MeshRenderer renderer in spriteAnimation.GetMeshRenderers())
            renderer.material = deadMaterial;
        
        spriteAnimation.ReplaceWithDeadSprite();
    }
}
