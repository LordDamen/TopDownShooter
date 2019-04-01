using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RagdollControl : MonoBehaviour
{

    public GameObject objectForRagdoll;
    // Things to turn off when we ragdoll, on when normal
    public Collider mainCollider;
    public Animator anim;
    public Rigidbody mainRigidbody;
    public NavMeshAgent agent;
    // Things to turn on when ragdoll, off when normal
    public List<Rigidbody> partRigidbodies;
    public List<Collider> partColliders;
    public Rigidbody weaponRB;

    // Use this for initialization
    void Start()
    {
        //Grab all inital components
        mainCollider = objectForRagdoll.GetComponent<Collider>();
        anim = objectForRagdoll.GetComponent<Animator>();
        mainRigidbody = objectForRagdoll.GetComponent<Rigidbody>();
        agent = objectForRagdoll.GetComponent<NavMeshAgent>();

        partRigidbodies = new List<Rigidbody>(objectForRagdoll.GetComponentsInChildren<Rigidbody>());
        partColliders = new List<Collider>(objectForRagdoll.GetComponentsInChildren<Collider>());

        // Deactivate the Ragdoll
        DeactivateRagdoll();
    }

    // Update is called once per frame
    void Update()
    {
        // for testing purposes
        /*
        if (Input.GetKeyDown(KeyCode.P))
        {
            ActivateRagdoll();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            DeactivateRagdoll();
        }
        */
    }

    public void ActivateRagdoll()
    {
        weaponRB = GetComponent<Pawn>().equippedWeapon.GetComponent<Rigidbody>();
        // Turn on all the child rigidbodies
        foreach (Rigidbody rb in partRigidbodies)
        {
            rb.isKinematic = false;
        }
        // Turn on all the child coliders 
        foreach (Collider col in partColliders)
        {
            col.enabled = true;
        }
        // Turn OFF the main stuff
        mainCollider.enabled = false;
        mainRigidbody.isKinematic = true;
        anim.enabled = false;
        agent.enabled = false;
        if (objectForRagdoll.GetComponent<Pawn>().equippedWeapon)
        {
            objectForRagdoll.GetComponent<Pawn>().equippedWeapon.GetComponent<Rigidbody>().isKinematic = false;
        }

    }

    public void DeactivateRagdoll()
    {
        // Turn OFF the ragdoll colliders
        foreach (Collider col in partColliders)
        {
            col.enabled = false;
        }
        // Turn OFF the ragdoll rigidbodies
        foreach (Rigidbody rb in partRigidbodies)
        {
            rb.isKinematic = true;
        }
        // Turn ON the main stuff
        mainCollider.enabled = true;
        mainRigidbody.isKinematic = false;
        agent.enabled = true;
        anim.enabled = true;
        if (objectForRagdoll.GetComponent<Pawn>().equippedWeapon)
        {
            objectForRagdoll.GetComponent<Pawn>().equippedWeapon.GetComponent<Rigidbody>().isKinematic = true;
            objectForRagdoll.GetComponent<Pawn>().equippedWeapon.transform.position = objectForRagdoll.GetComponent<Pawn>().weaponPoint.position;
        }

    }
}
