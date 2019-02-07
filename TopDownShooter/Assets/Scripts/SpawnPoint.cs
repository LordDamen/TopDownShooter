using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {


    public float respawnTime;
    public GameObject objectToSpawn;
    public GameObject spawnedObject;
    public float timeUntilRespawn;
    private Transform tf;

    private void Awake()
    {
        tf = GetComponent<Transform>();
    }
    // Use this for initialization
    void Start () {
        Spawn();
	}
	
	// Update is called once per frame
	void Update () {
		// Check if spawned object is alive
        if (spawnedObject == null)
        {
            //If the object doesnt exist start the timer
            timeUntilRespawn -= Time.deltaTime;
            //if it is 0 then respawn
            if (timeUntilRespawn <= 0)
            {
                Spawn();
            }
        } // Else Do nothing
	}
    public void Spawn ()
    {
        //Create the object
        spawnedObject = Instantiate(objectToSpawn, tf.position, tf.rotation);
        //Reset the respawn time
        timeUntilRespawn = respawnTime;
    }
}
