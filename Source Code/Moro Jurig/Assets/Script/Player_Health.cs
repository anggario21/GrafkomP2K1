using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 0;
    public float lastTimeHit;

    public event Action<float> OnHealthPctChanged = delegate { };
	// Use this for initialization
	private void OnEnable ()
    {
        currentHealth = maxHealth;
	}
	
    public void TakeDamage(int _damage)
    {
        lastTimeHit = Time.time;
        currentHealth -= _damage;
        float currentHealthPct = (float) currentHealth / (float) maxHealth;
        OnHealthPctChanged(currentHealthPct);

        if(currentHealth <= 0)
        {
            Invoke ("Die", 2.0f)    ;
        }
    }

    void Die()
    {
        SceneManager.LoadScene(2);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public int getCurrHealth()
    {
        return currentHealth;
    }
}
