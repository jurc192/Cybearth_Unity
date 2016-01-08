using UnityEngine;
using System.Collections;

public class HealthBoxTriggerHandler : MonoBehaviour {

    private float heal = 20;

	// Use this for initialization
	void Start () {
	}
	
	void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().Heal(heal);
            Destroy(gameObject);
        }
    }
}
