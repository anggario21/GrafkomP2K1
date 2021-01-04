using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PocongChase : MonoBehaviour
{

    private NavMeshAgent Pocong;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        Pocong = GetComponent<NavMeshAgent>();
    }


    // Update is called once per frame
    void Update()
    {
        Pocong.SetDestination(target.position);
    }

}
