using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool open = false; //nyimpen kondisi pintu
    public float doorOpenAngle = 90f;
    public float doorClosedAngle = 0f;
    public float speedRotation = 2f;

    public bool hasOpenedCompletely;

    public bool firstOpen=false;
    public bool check = false;

    public bool isLock = false;
    public bool lockedNow = false;

    private AudioSource audioSource;
    public AudioClip openingDoorSound;
    public AudioClip lockDoorSound;

    //trigger hantu
    public GameObject pocong_awal;
    public GameObject hantu1;
    public GameObject hantu2;
    public GameObject hantu3;
    public GameObject pocong_boss;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ChangeDoorState()
    {
        if(!isLock) { 
            open = !open;

            if(audioSource != null)
            {
                audioSource.PlayOneShot(openingDoorSound);

            }
        } else
        {
            if (audioSource != null)
            {
                audioSource.PlayOneShot(lockDoorSound);

            }
        }
    }

    public void LockDoor()
    {
        isLock = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLock)
        {
            if (open)
            {
                //buka pintu
                if (hasOpenedCompletely == false)
                {
                    Quaternion targetRotationOpen = Quaternion.Euler(0, 0, doorOpenAngle);
                    transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationOpen, speedRotation * Time.deltaTime);

                    firstOpen = true;

                    if (transform.localRotation == targetRotationOpen)
                    {
                        hasOpenedCompletely = true;
                    }
                }
            }
            else
            {
                //tutup pintu
                Quaternion targetRotationClosed = Quaternion.Euler(0, 0, doorClosedAngle);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationClosed, speedRotation * Time.deltaTime);
                if (transform.localRotation == targetRotationClosed)
                {
                    hasOpenedCompletely = false;
                    if(lockedNow == true)
                    {
                        isLock = true;
                    }
                }
            }
        }

        if (hasOpenedCompletely == true) check = true;

        if (firstOpen==true) 
        {

            if (hantu1 != null)
            {
                hantu1.GetComponent<Enemy_Chase>().enabled = true;
            }

            if (hantu2 != null)
            {
                hantu2.GetComponent<Enemy_Chase>().enabled = true;
            }

            if (hantu3 != null)
            {
                hantu3.GetComponent<Enemy_Chase>().enabled = true;
            }

            if (pocong_boss != null)
            {
                pocong_boss.GetComponent<Pocong_Movement>().enabled = true;
            }
        }

        if (check == true)
        {
            if (pocong_awal != null)
            {
                pocong_awal.SetActive(false);
            }
        }

    }

}
