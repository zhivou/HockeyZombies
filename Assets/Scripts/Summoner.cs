using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoner : Enemy{

    public float minX;
    public float minY;
    public float maxX;
    public float maxY;
    public float timeBetweenSummons;
    public Enemy enemyToSummon;
    public int costsCounts;

    private Vector2 targetPostition;
    private Animator anim;
    private float summonTime;
    private int costCounter;

    // Here is an ovveride method wich overwrites original superclass method.
    // Require to add virtual to a parant method in order to let c# overwrite it.
    // base.Start(); - like super in Ruby - run both parent and child methods.
    public override void Start(){
        base.Start();
        costCounter = 1;
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        targetPostition = new Vector2(randomX, randomY);
        anim = GetComponent<Animator>();
    }

    private void Update(){
        anim.SetBool("isRunning", false);
        float targetDistance;
        targetDistance = Vector2.Distance(transform.position, targetPostition);

        if (targetDistance > .5f)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPostition, speed * Time.deltaTime);
            anim.SetBool("isRunning", true);
        }
        else{
            anim.SetBool("isRunning", false);
            if(Time.time >= summonTime)
            {
                summonTime = Time.time + timeBetweenSummons;
                anim.SetTrigger("summon");
                
            }
        }
    }

    public void Summon(){
        Debug.Log(costCounter);
        if (player != null && costCounter <= costsCounts){
            Instantiate(enemyToSummon, transform.position, transform.rotation);
            costCounter++;
        }
        else{
            anim.SetTrigger("summonIdle");
        }
    }
}
