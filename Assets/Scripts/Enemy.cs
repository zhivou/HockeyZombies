using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;

    public void TakeDamage(int damageAmout)
    {
        health -= damageAmout;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
