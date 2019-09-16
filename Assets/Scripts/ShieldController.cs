using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    public void DestroyShield()
    {
        for (int a = 0; a < transform.childCount; a++)
        {
            Transform column = transform.GetChild(a);
            for (int i = column.childCount - 1; i >= 0; i--)
            {
                ShieldModuleCollider moduleScript = column.GetChild(i).gameObject.GetComponent<ShieldModuleCollider>();
                moduleScript.MakeInactive();
                

            }
            for (int i = column.childCount - 1; i >= 0; i--)
            {
                Transform sibling = column.GetChild(i);

                sibling.parent = null;
            }
        }
    }
}
