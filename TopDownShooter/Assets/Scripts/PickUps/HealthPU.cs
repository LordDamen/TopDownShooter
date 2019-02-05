using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPU : PickUp {

    public int healAmount;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public override void OnPickup(GameObject target)
    {
        Health targethealth = target.GetComponent<Health>();
        if (targethealth != null)
        {
            targethealth.HealDamage(healAmount);
        } 
        base.OnPickup(target);
    }
}
