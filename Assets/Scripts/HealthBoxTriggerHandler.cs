using UnityEngine;
using System.Collections;

public class HealthBoxTriggerHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
