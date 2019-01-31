using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour {
    public Transform targetObjectTransform;
    public Vector3 offset;
    private Transform tf;
	// Use this for initialization
	void Start () {
        tf = gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
        tf.position = targetObjectTransform.position + offset;
        tf.LookAt(targetObjectTransform.position);

	}
}
