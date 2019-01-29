using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour {

    [SerializeField]
    public Animator anim;
    [SerializeField]
    public Transform tf;
    [SerializeField]
    public float turnSpeed;
    [SerializeField]
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
            anim.SetFloat("Vertical", direction.z );
            anim.SetFloat("Horizontal", direction.x);
        }
        public void RotateTowards(Vector3 targetPoint)
        {
            Vector3 toLookDown = targetPoint - tf.position ;
            Quaternion lookRotation =  Quaternion.LookRotation(toLookDown, tf.up);
            tf.rotation = Quaternion.RotateTowards(tf.rotation, lookRotation, turnSpeed * Time.deltaTime);
        }
}
