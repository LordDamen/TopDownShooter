using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour {

     public Animator anim;

        void Start()
        {
            anim = GetComponent<Animator>();
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
