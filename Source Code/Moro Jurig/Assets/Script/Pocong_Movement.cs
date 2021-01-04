using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Pocong_Movement : MonoBehaviour
{
    private NavMeshAgent myAgent;
    private Animator myAnimator;

    public Transform target;

    public bool chaseTarget = true;
    public float stopingDistance = 2.5f;
    public float delayBetweenAttacks = 1.5f;
    private float attackCooldown;

    private float distanceFromTarget;

    public AudioSource suaraTubuh1;
    public AudioClip uhUhSound1;

    public int damage = 50;
    private Player_Health playerHealth;

    float delaytimer;
    Vector3 pos;
    //public GameObject obj;

    // Use this for initialization
    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        //myAnimator = GetComponent<Animator>();
        myAgent.stoppingDistance = stopingDistance;
        attackCooldown = Time.time;
        getNewPosition(); // get initial targetpos

        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Health>();
    }

    // Update is called once per frame
    void Update()
    {
        delaytimer += Time.deltaTime;
        distanceFromTarget = Vector3.Distance(target.position, transform.position);

        if (delaytimer > 7) // time to wait 
        {
            getNewPosition(); //get new position every 1 second
            delaytimer = 0f; // reset timer
            chaseTarget = false;
            //myAnimator.SetBool("isChasing", false);
        }
        else if (delaytimer > 3 && delaytimer < 4)
        { 
            pos = target.position;
            chaseTarget = true;
            //myAnimator.SetBool("isChasing", true);
        }

        if (distanceFromTarget <= stopingDistance)
        {
            Attack();
        }

        //transform.position = Vector3.MoveTowards(transform.position, pos, .1f);
        myAgent.SetDestination(pos);
    }

 /*   void ChaseTarget()
    {
        distanceFromTarget = Vector3.Distance(target.position, transform.position);
        if (distanceFromTarget >= stopingDistance)
        {
            chaseTarget = true;
        }
        else
        {
            chaseTarget = false;
            Attack();
        }

        if (chaseTarget)
        {
            myAgent.SetDestination(target.position);
            //myAnimator.SetBool("isChasing", true);
        }
        else
        {
            // myAnimator.SetBool("isChasing", false);
        }
    } */

    void Attack()
    {
        if (Time.time > attackCooldown)
        {
            playerHealth.TakeDamage(damage);
            if (suaraTubuh1 != null)
            {
                suaraTubuh1.PlayOneShot(uhUhSound1);
            }
            //myAnimator.SetTrigger("Attack");
            attackCooldown = Time.time + delayBetweenAttacks;
        }
    }

    void getNewPosition()
    {
        float x = Random.Range(16.7f, 29.2f);
        float z = Random.Range(-0.75f, -18.75f);

        pos = new Vector3(x, 0, z);
    }

}
