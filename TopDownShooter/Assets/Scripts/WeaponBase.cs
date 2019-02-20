using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponBase : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform rightHandTf;
    public Transform leftHandTf;
    public Transform shootPoint;

    public int shotCount;
    public float spread;
    public int ammoCount;
    [SerializeField] private float rateOfFire;
    [SerializeField] private int damage;
    private float timer;
    private Text ammoText;

    public enum WeaponType { None = 0, Pistol = 1, Rifle = 2}
    public WeaponType weaponType;

	// Use this for initialization
	void Start () {
        ammoText = GameObject.Find("Ammo Text").GetComponent<Text>();
        if (ammoText.text == "New Text") {
            ammoText.text = "No Weapon";
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnEquip(Pawn pawn)
    {
        pawn.RHPoint = rightHandTf;
        pawn.LHPoint = leftHandTf;
        UpdateAmmoText();
    }

    public void OnShoot()
    {
        if (Time.time >= timer && ammoCount > 0) {
            GameObject tempObject;

            for (int i = 0; i < shotCount; i++)
            {
                // Spawn a projectile
                tempObject = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation * Quaternion.Euler(Random.onUnitSphere * spread));
                tempObject.layer = gameObject.layer;
                tempObject.GetComponent<BulletScript>().damage = damage;
                Destroy(tempObject, 5);
            }
            ammoCount--;
            UpdateAmmoText();
            timer = Time.time + 60 /rateOfFire;
        }
    }

    public void UpdateAmmoText()
    {
        ammoText.text = "Ammo: " + ammoCount;
    }
}
