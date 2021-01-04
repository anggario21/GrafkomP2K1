using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Light flashlight;
    public AudioSource audioSource;
    public AudioClip soundFlashlightON;
    public AudioClip soundFlashlightOFF;
    private bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        isActive = false;    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(isActive) 
            {
                flashlight.enabled = false;
                isActive = false;
                audioSource.PlayOneShot(soundFlashlightOFF);
            }
            else 
            {
                flashlight.enabled = true;
                isActive = true;
                audioSource.PlayOneShot(soundFlashlightON);
            }
        }
    }
}
