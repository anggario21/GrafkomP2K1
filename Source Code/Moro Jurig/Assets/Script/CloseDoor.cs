using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    public GameObject pintu1;
    public GameObject pintu2;
    public GameObject hantuboss1;
    public GameObject hantuboss2;
    public GameObject hantuboss3;
    public GameObject pocongboss;

    public bool hasPlay = false; 
    private bool hasClosed = false;
    public AudioSource audioSourceBoss;
    public AudioClip audioClipBoss;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(!hasClosed) {
                if(pintu1!=null)
                {
                    pintu1.GetComponent<Door>().ChangeDoorState();
                    pintu1.GetComponent<Door>().lockedNow = true;
                }
                if(pintu2!=null)
                {
                    pintu2.GetComponent<Door>().ChangeDoorState();
                    pintu2.GetComponent<Door>().lockedNow = true;
                }
            }
            

            if (!hasPlay) { 
                audioSourceBoss.PlayOneShot(audioClipBoss);
                hasPlay = true;
            }

            if (hantuboss1 != null)
            {
                hantuboss1.GetComponent<random>().enabled = true;
                hantuboss1.GetComponent<Enemy_Chase>().enabled = true;
            }

            if (hantuboss2 != null)
            {
                hantuboss2.GetComponent<random>().enabled = true;
                hantuboss2.GetComponent<Enemy_Chase>().enabled = true;
            }

            if (hantuboss3 != null)
            {
                hantuboss3.GetComponent<random>().enabled = true;
                hantuboss3.GetComponent<Enemy_Chase>().enabled = true;
            }

            if (pocongboss != null)
            {
                pocongboss.GetComponent<Pocong_Movement>().enabled = true;
            }
        }
    }
}
