using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int lives;
    
    public void Die()
    {
        lives -= 1;



        if(lives==0)
        {

        }
    }
}
