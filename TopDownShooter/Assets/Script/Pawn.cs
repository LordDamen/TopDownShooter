using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour {

     public Animator anim;
    public Transform tf;
        void Start()
        {
            anim = GetComponent<Animator>();
        tf = GetComponent<Transform>();
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void Move(Vector3 direction)
        {
            anim.SetFloat("Vertical", direction.x);
            anim.SetFloat("Horizontal", direction.z);
        }
}
