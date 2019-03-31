using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    private NavMeshAgent TheMeshAgent;
    public GameObject target;
    private Transform character;
    public Pawn pawn;
    public float moveSpeed;
    public float maxRange;
    private Animator anim;
    private GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        TheMeshAgent = GetComponent<NavMeshAgent>();
        pawn = GetComponent<Pawn>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    // This is the function that allows for the enemy to move
    public void Movement ()
    {
        // setting the target to the player
        TheMeshAgent.SetDestination(target.transform.position);
        //converting the target to a vector 3
        Vector3 desiredVelocity = TheMeshAgent.desiredVelocity * moveSpeed;
        Vector3 Input = Vector3.MoveTowards(desiredVelocity, TheMeshAgent.desiredVelocity, TheMeshAgent.acceleration * Time.deltaTime);
        Input = transform.InverseTransformDirection(Input);
        anim.SetFloat("Horizontal", Input.x);
        anim.SetFloat("Vertical", Input.z);
    }
    private void OnAnimatorMove()
    {
        TheMeshAgent.velocity = anim.velocity;
    }
}
