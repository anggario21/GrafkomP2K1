using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bapet_Trigger : MonoBehaviour
{
    public GameObject bapetspawner;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bapetspawner.SetActive(true);
        }
    }
}
