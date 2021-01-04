using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolInteract : MonoBehaviour
{
    public AudioClip pickupSound;
    public GameObject pistol;

    public void PickupPistol()
    {
        //GetComponent<AudioSource>().PlayOneShot(pickupSound);
        pistol.SetActive(true);

        Destroy(gameObject);
    }
}
