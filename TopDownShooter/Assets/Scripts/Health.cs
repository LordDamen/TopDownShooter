using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {


    public int maxHealth;
    public int currentHealth;

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        HealthTextUpdate();
	}

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth == 0) Destroy(gameObject);
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
    public void HealthTextUpdate()
    {
        // Check if its the player
        if (this.tag == "Player")
        {
            Text Health = GameObject.Find("Health Text").GetComponent<Text>();
            Health.text = "Current Health:" + currentHealth;
        }
        // if it isnt the player than do nothing
    }
}
