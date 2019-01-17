using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    public Pawn pawn;
    public Transform testObject; // Delete LAter
	// Use this for initialization
	void Start () {
        pawn = GetComponent<Pawn>();
	}
	
	// Update is called once per frame
	void Update () {
        Rotation();
        Movement();
	}
    void Rotation()
    {
        //create a plane object
        Plane theplane = new Plane(Vector3.up,pawn.tf.position);
        //raycast out the camera at mouse position to plane --- find the distance to the plane
        float distance;
        Ray theRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        theplane.Raycast(theRay, out distance);
        //find a point on the ray thats is the "distance " down the ray
        Vector3 targetPoint =theRay.GetPoint(distance);
        //test
        testObject.position = targetPoint;
    }
    void Movement ()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        // a vector cant be longer than this
        moveDirection = Vector3.ClampMagnitude(moveDirection, 1);
        // for world direction
        moveDirection = pawn.tf.InverseTransformDirection(moveDirection);

        pawn.Move(moveDirection);
    }
}
