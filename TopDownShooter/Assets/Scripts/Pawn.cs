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
    [SerializeField]
    public float stamina = 1f;
    [SerializeField]
    public float staminaDepleteTimer = 5f;
    [SerializeField]
    public float staminaRegenTimer = 3f;
    [SerializeField]
    public KeyCode runningKey;
    [SerializeField]
    public bool isTired = false;
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
        anim.SetFloat("Vertical", direction.z*moveSpeed);
        anim.SetFloat("Horizontal", direction.x*moveSpeed);
    }
    public void RotateTowards(Vector3 targetPoint)
    {
        Vector3 toLookDown = targetPoint - tf.position ;
        Quaternion lookRotation =  Quaternion.LookRotation(toLookDown, tf.up);
        tf.rotation = Quaternion.RotateTowards(tf.rotation, lookRotation, turnSpeed * Time.deltaTime);
    }
    public void Running()
    {
        if (isTired == false)
        {
            stamina -= Time.deltaTime / staminaDepleteTimer;
            anim.SetBool("IsRunning", true);
        } 
        if (stamina <=0 || isTired == true)
        {
            isTired = true;
            stamina += Time.deltaTime / staminaRegenTimer;
            anim.SetBool("IsRunning", false);
        }
        stamina = Mathf.Clamp01(stamina);
        if (isTired == true && stamina >= 1f) isTired = false;
    }
}
