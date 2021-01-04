using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLorong : MonoBehaviour
{
    public AudioClip huaaahhSFX;
    public AudioSource audioSource;
    private bool hasPlay=false;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && hasPlay==false)
        {
            audioSource.PlayOneShot(huaaahhSFX);
            hasPlay = true;
        }
    }
}
