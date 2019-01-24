using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour {

    public Animator anim;
    public Transform tf;
    public float turnSpeed;
    public float moveSpeed;
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
            anim.SetFloat("Vertical", direction.x * moveSpeed);
            anim.SetFloat("Horizontal", direction.z*moveSpeed);
        }
        public void RotateTowards(Vector3 targetPoint)
        {
            Vector3 toLookDown = targetPoint - tf.position ;
            Quaternion lookRotation =  Quaternion.LookRotation(toLookDown, tf.up);
            tf.rotation = Quaternion.RotateTowards(tf.rotation, lookRotation, turnSpeed * Time.deltaTime);
        }
}
