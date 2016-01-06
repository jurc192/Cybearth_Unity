using UnityEngine;
using System.Collections;

public class AmmoBoxTriggerHandler : MonoBehaviour {

    WeaponInventory weaponInventory;

	// Use this for initialization
	void Start () {
        weaponInventory = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<WeaponInventory>();
	}
	
	void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Weapon weapon = weaponInventory.CurrentWeapon;
            weapon.addBullets(weapon.ClipSize);
            Destroy(gameObject);
        }
    }
}
