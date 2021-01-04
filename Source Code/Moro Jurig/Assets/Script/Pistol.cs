using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pistol : MonoBehaviour
{
	public int damage=50;
	public int ammo=20;
	public int currentAmmo;
	public float range=50;
	private bool isReloading=false;

	private Transform mainCamera;
	
	private AudioSource myAudioSource;
	public AudioClip shootSound;
    public AudioClip reloadSound;

    public GameObject pistoldipegang;
    public GameObject bulletPrefab;
    public Camera playerCamera;

    private Animator myAnimator;
    private float lastFired;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        currentAmmo=ammo;
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    	if(isReloading) return;
    	if(currentAmmo<=20 && Input.GetButtonDown("Reload")){
    		StartCoroutine(Reload());
    		return; 
    	}

        if (Input.GetButtonDown("Fire1") && pistoldipegang && currentAmmo > 0 && !isReloading)
        {
            myAnimator.SetBool("isFire", true);
            Shoot();
        } else { 
            myAnimator.SetBool("isFire", false);
        }

    }

    IEnumerator Reload()
    {
        myAudioSource.PlayOneShot(reloadSound);
    	isReloading=true;
        myAnimator.SetBool("isReload", true);

        yield return new WaitForSeconds(2);

    	currentAmmo=ammo;
    	isReloading=false;
        myAnimator.SetBool("isReload", false);
    }

    void Shoot()
    {
        GameObject bulletObject = Instantiate(bulletPrefab);
        bulletObject.transform.position = playerCamera.transform.position + playerCamera.transform.forward;
        bulletObject.transform.forward = playerCamera.transform.forward;

        currentAmmo--;

        //Raycast
        Ray ray = new Ray(mainCamera.position, mainCamera.forward);
    	RaycastHit hit;

    	if(Physics.Raycast(ray, out hit, range))
    	{
    		if(hit.collider.CompareTag("Enemy"))
    		{
    			//Damage the enemy
    			hit.collider.GetComponent<Enemy_Health>().TakeDamage(damage);
    		}
    	}
    	myAudioSource.PlayOneShot(shootSound);
    	
    }
}
