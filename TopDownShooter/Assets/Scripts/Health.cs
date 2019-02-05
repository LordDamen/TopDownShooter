using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {


    public int maxHealth;
    public int currentHealth;

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
    }

    public void HealDamage(int amount)
    {
        
        if (currentHealth == maxHealth)
        {
            // Do Nothing
        } else
        {
            currentHealth += amount;
        }
    }
}
