﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public float speed;
    public int damage;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * speed, ForceMode.VelocityChange);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collider)
    {
        Debug.Log("Collied with" + collider.gameObject.name); 
        GameObject tempObject = collider.gameObject;
        if (tempObject.GetComponent<Health>() != null)
        {
            tempObject.GetComponent<Health>().TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
