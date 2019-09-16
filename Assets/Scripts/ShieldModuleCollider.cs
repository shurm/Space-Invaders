using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldModuleCollider : MonoBehaviour
{
    public Material deadMaterial;

    private void OnCollisionEnter(Collision other)
    {
        if (transform.parent == null)
            return;
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("AlienBullet") || other.gameObject.CompareTag("PlayerBullet"))
        {
            other.gameObject.tag = "Untagged";

            Transform parent = transform.parent;
            for (int i = parent.childCount - 1; i >= 0; i--)
            {
                GameObject sibling = parent.GetChild(i).gameObject;
                MeshRenderer mr = sibling.GetComponent<MeshRenderer>();
                mr.material = deadMaterial;
                Rigidbody rb = sibling.GetComponent<Rigidbody>();
                rb.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionZ;
                rb.useGravity = true;

            }
            for (int i = parent.childCount - 1; i >= 0; i--)
            {
                Transform sibling = parent.GetChild(i);
                sibling.parent = null;
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (transform.parent == null)
            return;
        if (other.gameObject.CompareTag("MissileExplosion"))
        {
            MeshRenderer mr = GetComponent<MeshRenderer>();
            mr.material = deadMaterial;
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionZ;
            rb.useGravity = true;
        }
    }
}
