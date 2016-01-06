using UnityEngine;
using System.Collections;

public class HealthBoxTriggerHandler : MonoBehaviour {

    WeaponInventory weaponInventory;

	// Use this for initialization
	void Start () {
        weaponInventory = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<WeaponInventory>();
	}
	
	void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
