using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoner : Enemy{

    public float minX;
    public float minY;
    public float maxX;
    public float maxY;

    private Vector2 targetPostition;
    private Animator anim;

    public override void Start(){
        base.Start();
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        targetPostition = new Vector2(randomX, randomY);
        anim = GetComponent<Animator>();
    }

    private void Update(){
        anim.SetBool("isRunning", false);
        float targetDistance;
        targetDistance = Vector2.Distance(transform.position, targetPostition);

        if(targetDistance > .5f){
            transform.position = Vector2.MoveTowards(transform.position, targetPostition, speed * Time.deltaTime);
            anim.SetBool("isRunning", true);
        }
    }
}
