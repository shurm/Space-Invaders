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

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        renderers = GetComponentsInChildren<MeshRenderer>();
    }
    private void Update()
    {
        //if dead
        if (transform.parent == null)
            return;

        if (transform.position.y < lowerYBound)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if(playerObject!=null)
                playerObject.GetComponentInParent<Health>().DiePermanently();
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        //if dead
        if (transform.parent == null)
            return;

        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            Transform aramada = transform.parent.parent;
            //ArmadaController armadaAttackController = aramada.GetComponent<ArmadaController>();

            //armadaAttackController.GoFaster();

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
            other.gameObject.tag = "Untagged";
        }

        if (other.gameObject.CompareTag("ShieldModules"))
        {
            Destroy(other.gameObject);
            return;
        }
    }
}
