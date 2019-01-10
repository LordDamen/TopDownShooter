using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    public Pawn pawn;
	// Use this for initialization
	void Start () {
        pawn = GetComponent<Pawn>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        pawn.Move(moveDirection);
	}
}
