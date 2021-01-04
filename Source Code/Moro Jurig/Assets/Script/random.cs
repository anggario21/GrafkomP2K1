using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random : MonoBehaviour
{
    float delaytimer;
    public float x1, x2, z1, z2;
    Vector3 pos;

void Start () {
    getNewPosition(); // get initial targetpos
      //  x1 = 0.22f;
      // x2 = 10;
      //  z1 = -9;
      //  z2 = -0.22f;
}

void Update () {
    delaytimer += Time.deltaTime;

    if (delaytimer > 2) // time to wait 
    {
        getNewPosition(); //get new position every 1 second
        delaytimer = 0f; // reset timer
    }
    transform.position = Vector3.MoveTowards(transform.position, pos, .1f);
}

void getNewPosition()
{
    float x = Random.Range(x1, x2);
    float z = Random.Range(z1, z2);

    pos = new Vector3(x, 0, z);
}
}
