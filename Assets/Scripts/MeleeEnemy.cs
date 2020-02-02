using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy {

    public float stopDistance;
    private float timeOffset;
    public float attackSpeed;

    ////
    // Distance method will calculate distance between player and current
    // position(transform.position).
    // MoveTowards is a Unity method to move current object towards to it.
    // Requires to pass a current object position, object which we use to move
    // towards to and a speed.
    void Update() {
        if(player != null) {
            if(Vector2.Distance(transform.position, player.position) > stopDistance) {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            } else {
                if(Time.time >= timeOffset) {
                    ////
                    // StartCoroutine is a away to run async functions from within
                    // Update in order to see it. For example Update method runs every frame
                    // and if we call Attack without Coroutine it will execute it within
                    // that frame time which is very fast and won't be posible to see.
                    StartCoroutine(Attack());
                    timeOffset = Time.time + timeBetweenAtack;
                }
            }
        }
    }

    ////
    // Lerp is an Unity function wich moves object from one postition to
    // onother with formula adjastments. animationProcent needs to be there to make
    // animation work with atack delay(speed). Formual is taken from the course not exatly
    // sure how they culculated it.
    // Also onece it's called it will use player script to remove health from it.
    IEnumerator Attack() {
        player.GetComponent<Player>().TakeDamage(damage);
        Vector2 originalPostition = transform.position;
        Vector2 targetPostition = player.position;

        float animationProcent = 0;
        while(animationProcent <= 1) {
            animationProcent += Time.deltaTime * attackSpeed;
            float formula = (-Mathf.Pow(animationProcent, 2) + animationProcent) * 4;
            transform.position = Vector2.Lerp(originalPostition, targetPostition, formula);
            yield return null;
        }

    }
}
