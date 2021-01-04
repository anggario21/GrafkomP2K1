using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilinInteract : MonoBehaviour
{
    public GameObject api;
    public GameObject cahaya;
    public GameObject bapetspawner;
    public bool isCancel = false;

    public void MatiLilin()
    {
        api.SetActive(false);
        cahaya.SetActive(false);
        isCancel = true;

        if (bapetspawner != null)
        {
            bapetspawner.GetComponent<Bapet_Spawn>().Cancel();
        }
    }
}
