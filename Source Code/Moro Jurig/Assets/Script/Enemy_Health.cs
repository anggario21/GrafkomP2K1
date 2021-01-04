using UnityEngine;
using System.Collections;
using System;

public class Enemy_Health : MonoBehaviour
{
    
    public int maxHealth = 100;
    private int currentHealth;
    

    public event Action<float> OnHealthPctChanged = delegate { };
    //private Animator animator;

	// Use this for initialization
	private void OnEnable ()
    {
        currentHealth = maxHealth;
        //animator = GetComponent<Animator>();
	}
	
	public void TakeDamage(int _damage)
    {
        currentHealth -= _damage;
        //animator.SetTrigger("isHit");
        float currentHealthPct = (float) currentHealth / (float) maxHealth;
        OnHealthPctChanged(currentHealthPct);

        if(currentHealth <= 0)
        {
            //Call Die Method
            Die();
        }
    }

    void Die()
    {
        //Kill the Enemy
        //Play an animation
        //Instantiate a ragdoll

        //Destroy the Enemy GO
        Destroy(gameObject, 0.5f);
    }

}
