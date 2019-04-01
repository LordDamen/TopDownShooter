using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pawn : MonoBehaviour {

    [SerializeField]
    public Animator anim;
    [SerializeField]
    public Transform tf;
    public float turnSpeed;
    public float moveSpeed;
    public float stamina = 1f;
    public float staminaDepleteTimer = 5f;
    public float staminaRegenTimer = 3f;
    public KeyCode runningKey;
    [SerializeField]
    public bool isTired = false;

    public GameObject equippedWeapon;
    public WeaponBase weaponScript;
    public Transform weaponPoint;



    public Transform RHPoint;
    public Transform LHPoint;
    void Start()
    {
        anim = GetComponent<Animator>();
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //check if we can shoot

        if (Input.GetMouseButton(0)&& equippedWeapon != null)
        {
            weaponScript.OnShoot();
        }

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
    public void OnEquip(GameObject newWeapon)
    {
        Destroy(equippedWeapon);
        RHPoint = null;
        LHPoint = null;
        equippedWeapon = newWeapon;
        equippedWeapon.layer = gameObject.layer;
        equippedWeapon.transform.parent = weaponPoint;
        equippedWeapon.transform.position = weaponPoint.transform.position;
        equippedWeapon.transform.rotation = weaponPoint.transform.rotation;
        weaponScript = equippedWeapon.GetComponent<WeaponBase>();
        weaponScript.OnEquip(this);

    }

    public void OnAnimatorIK(int layerIndex)
    {

        if (RHPoint != null)
        {
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1.0f);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1.0f);
            //set ik position
            anim.SetIKPosition(AvatarIKGoal.RightHand, RHPoint.position);
            anim.SetIKRotation(AvatarIKGoal.RightHand, RHPoint.rotation);
        } else
        {
            // IK weight is 0 - - use 100% animation data to move hands (0% IK Data)
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0.0f);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0.0f);
        }
        if (LHPoint != null)
        {
            // IK weight is 0 - - use 100% animation data to move hands (0% IK Data)
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1.0f);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1.0f);
            //set ik position
            anim.SetIKPosition(AvatarIKGoal.LeftHand, LHPoint.position);
            anim.SetIKRotation(AvatarIKGoal.LeftHand, LHPoint.rotation);
        } else
        {
            // IK weight is 0 - - use 100% animation data to move hands (0% IK Data)
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0.0f);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0.0f);
        }
    }
    public void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag == "Weapon")
        {
            OnEquip(collider.gameObject);
        }
    }

}
