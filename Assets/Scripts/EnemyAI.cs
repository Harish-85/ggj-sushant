using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{


    [SerializeField] NavMeshAgent ai;
    [SerializeField] List<Transform> destinations;
    [SerializeField] Animator anim;
    [SerializeField] float walkSpeed, chaseSpeed, maxIdleTime, minIdleTime, rayCastDistance= 15f , chaseDistance;
    bool walking, chasing;
    [SerializeField] int destinationAmount;
    [SerializeField] Transform player;
    Transform currentDestination;
    Vector3 dest;
    int randNum, randNum2;
    [SerializeField] float idleTime;// amount of seconds the AI will be idle

    [SerializeField] Vector3 rayCastOffset; // for better ai raycast 

    //Chase Variables
    [SerializeField] float chaseTime, minChaseTime, maxChaseTime;

    [SerializeField] float jumpScareTime;

    [SerializeField] string deathScene;
    // Start is called before the first frame update
    void Start()
    {
        walking = true;
        randNum = Random.Range(0,destinationAmount);
        currentDestination = destinations[randNum];
    }

    // Update is called once per frame
    void Update()
    {
       
        Vector3 playerDirection = (player.position - transform.position); // this vector will always be pointing towards the player.
        float distanceToPlayer = playerDirection.magnitude;
       
        Debug.Log(distanceToPlayer+" "+ rayCastDistance);

        if (distanceToPlayer <= rayCastDistance)
        {
            walking = false;
            StopCoroutine(StayIdle());
            StopCoroutine(Chase());
            StartCoroutine(Chase());
            anim.ResetTrigger("idle");
            anim.ResetTrigger("walk");
            anim.SetTrigger("sprint");
            chasing = true;
        }
        AIMovement();
    }

    void AIMovement()
    {
        if (chasing)
        {
            Debug.Log("chasing");
            dest = player.position;
            ai.destination = dest;
            ai.speed = chaseSpeed;
            if (ai.remainingDistance <= chaseDistance)
            {
                player.gameObject.SetActive(false);
                anim.ResetTrigger("walk");
                anim.ResetTrigger("idle");
                anim.ResetTrigger("sprint");
                anim.SetTrigger("jumpscare");
                StartCoroutine(Death());
                chasing = false;
            }
        }


        if (walking)
        {
            Debug.Log("Walking");
            dest = currentDestination.position;
            ai.destination = dest;
            ai.speed = walkSpeed;
            if (ai.remainingDistance <= ai.stoppingDistance)
            {
                randNum2 = Random.Range(0, 2);
                if (randNum2 == 0)
                {
                    randNum = Random.Range(0, destinationAmount);
                    currentDestination = destinations[randNum];
                }

                if (randNum == 1)
                {
                    anim.ResetTrigger("sprint");
                    anim.ResetTrigger("walk");
                    anim.SetTrigger("idle");
                    ai.speed = 0;
                    StopCoroutine(StayIdle());
                    StartCoroutine(StayIdle());
                    walking = false;
                }
            }

        }
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(jumpScareTime);
        SceneManager.LoadScene(deathScene);
    }
    IEnumerator Chase()
    {
        chaseTime = Random.Range(minChaseTime,maxChaseTime);
        yield return new WaitForSeconds(chaseTime);
        walking = true;
        chasing = false;
        randNum = Random.Range(0, destinationAmount);
        currentDestination = destinations[randNum];
        anim.ResetTrigger("sprint");
        anim.ResetTrigger("idle");
        anim.SetTrigger("walk");

    }
    IEnumerator StayIdle()
    {
        idleTime = Random.Range(minIdleTime, maxIdleTime);
        yield return new WaitForSeconds(idleTime);
        walking = true;
        randNum = Random.Range(0 , destinationAmount);
        currentDestination = destinations[randNum];
        anim.ResetTrigger("sprint");
        anim.ResetTrigger("idle");
        anim.SetTrigger("walk");
    }
}
