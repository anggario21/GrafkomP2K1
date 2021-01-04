using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageOverlay : MonoBehaviour
{
	public Image overlayImage;
    private int temp;

    public GameObject health;

	private float r;
	private float g;
	private float b;
	private float a;


    // Start is called before the first frame update
    void Start()
    {
        r=overlayImage.color.r;
        g=overlayImage.color.g;
        b=overlayImage.color.b;
        a=0f;

        temp = health.GetComponent<Player_Health>().currentHealth;
    }

    
    // Update is called once per frame
    void Update()
    {
        if(temp <= health.GetComponent<Player_Health>().currentHealth)
        {
        	a -= 0.01f;
        } else {
        	a += 0.01f;
        }
        a = Mathf.Clamp(a,0,1f);
        AdjustColor();

        if (health.GetComponent<Player_Health>().lastTimeHit + 2f < Time.time  ) // time to wait 
        {
            temp = health.GetComponent<Player_Health>().currentHealth;
        }
    }
    void AdjustColor()
    {
    	Color c = new Color(r,g,b,a);
        overlayImage.color=c;
    }
}
