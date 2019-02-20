using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public float respawnTime;
    public GameObject objectToSpawn;
    private GameObject spawnedObject;
    private float timeUntilNextSpawn;
    private Transform tf;

    // Use this for initialization
    void Start () {
        tf = gameObject.transform;
        Spawn();
    }
	
	// Update is called once per frame
	void Update () {
        //reduces timer is object does not exist
        if (spawnedObject == null) timeUntilNextSpawn -= Time.deltaTime;

        //if timer is done, spawns new object 
        if (timeUntilNextSpawn <= 0) Spawn();
	}

    public void Spawn()
    {
        //create object
        spawnedObject = Instantiate(objectToSpawn, tf.position + new Vector3 (0, 1, 0), tf.rotation);
        //reset respawn timer
        timeUntilNextSpawn = respawnTime;
    }
}
