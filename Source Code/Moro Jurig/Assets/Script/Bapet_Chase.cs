using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Bapet_Chase : MonoBehaviour
{
    private NavMeshAgent myAgent;
    //private Animator myAnimator;

    private Transform target;

    public bool chaseTarget = true;
    public float stopingDistance = 2.5f;
    public float delayBetweenAttacks = 1f;
    private float attackCooldown;

    private float distanceFromTarget;

    public int damage = 10;
    private Player_Health playerHealth;
    private AudioSource audioSourceBabi;
    public AudioClip suarababi;

    private AudioSource suaraTubuh2;
    public AudioClip uhUhSound2;

    public GameObject Lilin;

    // Use this for initialization
    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        //myAnimator = GetComponent<Animator>();
        myAgent.stoppingDistance = stopingDistance;
        attackCooldown = Time.time;

        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Health>();
        suaraTubuh2 = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Lilin = GameObject.FindGameObjectWithTag("lilin");

        audioSourceBabi = GameObject.FindGameObjectWithTag("BapetSpawner").GetComponent<AudioSource>();

        audioSourceBabi.loop = true;
        audioSourceBabi.clip = suarababi;
        audioSourceBabi.Play();
    }

    // Update is called once per frame
    void Update()
    {
        ChaseTarget();

        if (Lilin.GetComponent<LilinInteract>().isCancel == true)
        {
            audioSourceBabi.Stop();
        }
    }

    void ChaseTarget()
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
    }

    void Attack()
    {
        if (Time.time > attackCooldown)
        {
            playerHealth.TakeDamage(damage);
            if (suaraTubuh2 != null)
            {
                suaraTubuh2.PlayOneShot(uhUhSound2);
            }
            Destroy(gameObject, 0.5f);
            attackCooldown = Time.time + delayBetweenAttacks;
            //myAnimator.SetTrigger("Attack");
            //attackCooldown = Time.time + delayBetweenAttacks;
        }
    }
}
