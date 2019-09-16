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
        //Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("AlienBullet") || other.gameObject.CompareTag("PlayerBullet"))
        {
            other.gameObject.tag = "Untagged";

            Transform parent = transform.parent;
            for (int i = parent.childCount - 1; i >= 0; i--)
            {
                ShieldModuleCollider moduleScript = parent.GetChild(i).gameObject.GetComponent<ShieldModuleCollider>();
                moduleScript.MakeInactive();

            }
            for (int i = parent.childCount - 1; i >= 0; i--)
            {
                Transform sibling = parent.GetChild(i);
                
                sibling.parent = null;
            }

        }
    }
    public void MakeInactive()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        mr.material = deadMaterial;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionZ;
        rb.useGravity = true;
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
