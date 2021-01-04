using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //speed
    public float speed = 8f;
    public float lifeDuration = 2f;

    public float lifeTimer;

    // Start is called before the first frame update
    void Start()
    {
        lifeTimer = lifeDuration;
    }

    // Update is called once per frame
    void Update()
    {
        //make bullet move
        transform.position += transform.forward * speed * Time.deltaTime;
        
        //cek waktu bullet
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0f) { 
            Destroy(this.gameObject);
        }
    }
}
