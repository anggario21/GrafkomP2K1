using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy_Chase : MonoBehaviour
{
    private NavMeshAgent myAgent;
    //private Animator myAnimator;

    public Transform target;

    public bool chaseTarget = true;
    public float stopingDistance = 2f;
    public float delayBetweenAttacks = 1.5f;
    private float attackCooldown;

    public AudioSource suaraTubuh;
    public AudioClip uhUhSound;

    private float distanceFromTarget;

    public int damage = 50;
    private Player_Health playerHealth;

	// Use this for initialization
	void Start ()
    {
        myAgent = GetComponent<NavMeshAgent>();
        //myAnimator = GetComponent<Animator>();
        //myAgent.stoppingDistance = stopingDistance;
        attackCooldown = Time.time;

        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Health>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        ChaseTarget();
    }

    void ChaseTarget()
    {
        distanceFromTarget = Vector3.Distance(target.position, transform.position);
        if(distanceFromTarget >= stopingDistance)
        {
            chaseTarget = true;
        }
        else
        {
            chaseTarget = false;
            Attack();
        }

        if(chaseTarget)
        {
            myAgent.SetDestination(target.position);
            //myAnimator.SetBool("isChasing", true);
        }
        else
        {
           // myAnimator.SetBool("isChasing", false);
        }
    }

    void Attack()
    {
        if(Time.time > attackCooldown)
        {
            playerHealth.TakeDamage(damage);
            if(suaraTubuh!=null)
            {
                suaraTubuh.PlayOneShot(uhUhSound);
            }
            //myAnimator.SetTrigger("Attack");
            attackCooldown = Time.time + delayBetweenAttacks;
        }
    }
}
