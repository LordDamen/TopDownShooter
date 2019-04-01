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
    public List<GameObject> weaponList;
    
    // Start is called before the first frame update
    void Start()
    {
        TheMeshAgent = GetComponent<NavMeshAgent>();
        pawn = GetComponent<Pawn>();
        anim = GetComponent<Animator>();
        WeaponGeneration();
        target = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (!target)
        {
            TheMeshAgent.isStopped = true;
            anim.SetFloat("Horizontal", 0f);
            anim.SetFloat("Vertical", 0f);
            return;
        }
        else
        {
            Movement();
            if (Vector3.Angle(gameObject.transform.forward, target.transform.position - gameObject.transform.position) < pawn.weaponScript.spread && Vector3.Distance(gameObject.transform.position, target.transform.position) <= maxRange)
            {
                pawn.weaponScript.OnShoot();
                pawn.weaponScript.ammoCount++;
            }
            
        }

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
    void WeaponGeneration ()
    {
        GameObject tempWeapon = Instantiate(weaponList[Random.Range(0, weaponList.Count)]);
        pawn.OnEquip(tempWeapon);
    }
}
