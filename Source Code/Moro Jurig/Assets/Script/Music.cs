using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource ads;
    public AudioClip musicInGame;
    public GameObject rBossTrigger;

    // Start is called before the first frame update
    void Start()
    {
        ads.loop = true;
        ads.clip = musicInGame;
        ads.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (rBossTrigger.GetComponent<CloseDoor>().hasPlay == true)
        {
            ads.Stop();
        }
    }
}
