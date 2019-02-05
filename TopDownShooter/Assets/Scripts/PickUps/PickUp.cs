using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUp : MonoBehaviour {

    public float RotateSpeed = 360;
    private Transform tf;
	// Use this for initialization
	void Start () {
        tf = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {

        spin();
	}

    void spin()
    {
        tf.Rotate(0, RotateSpeed * Time.deltaTime, 0);
    }
    protected virtual void OnPickup (GameObject target)
    {
        // For whatever a pickup does when we call the base pickup
        Debug.Log(target.name + "picked Up a powerup");
        Destroy(gameObject);
    }
    public void OnTriggerEnter(Collider other)
    {
        OnPickup(other.gameObject);
    }
}
