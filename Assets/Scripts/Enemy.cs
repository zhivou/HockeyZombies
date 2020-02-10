using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int health;
    public float speed;
    public float timeBetweenAtack;
    public int damage;

    [HideInInspector]
    public Transform player;

    // This will find a player object by tag name - Player
    // vitrtual in to make it ovetwriteble
    public virtual void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void TakeDamage(int damageAmout) {
        health -= damageAmout;
        if(health <= 0) {
            Destroy(gameObject);
        }
    }
}
