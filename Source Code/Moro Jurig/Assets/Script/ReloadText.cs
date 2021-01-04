using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadText : MonoBehaviour
{   
    public int maxAmmo=20;
    public int ammo;
    public bool isFiring;
    public Text ammoDisplay;
    private bool isReloading = false;
    // Start is called before the first frame update
    void Start()
    {
        ammo=maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        ammoDisplay.text = ammo.ToString();
        if(Input.GetMouseButtonDown(0) && !isFiring && ammo > 0 && !isReloading)
        {
            isFiring = true;
            ammo--;
            isFiring = false;
        }
        if(ammo<=20 && Input.GetButtonDown("Reload")){
           StartCoroutine(Reload());
        return;         
        }
    }

    IEnumerator Reload()
    {

        isReloading = true;

        yield return new WaitForSeconds(2);

        ammo=maxAmmo;
        isReloading = false;
    }

}
