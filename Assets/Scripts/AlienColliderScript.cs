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

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        renderers = GetComponentsInChildren<MeshRenderer>();
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("PlayerBullet") && transform.parent!=null)
        {
            Transform aramada = transform.parent.parent;
            ArmadaController armadaAttackController = aramada.GetComponent<ArmadaController>();

            armadaAttackController.GoFaster();

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
}
