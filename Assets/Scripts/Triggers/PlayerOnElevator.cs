using UnityEngine;
using System.Collections;

public class PlayerOnElevator : MonoBehaviour {
    FirstPersonController fpsc;
    ElevatorHandler eh;

	// Use this for initialization
	void Start () {
	    fpsc = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        eh = transform.parent.GetComponentInChildren<ElevatorHandler>();
    }
	
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            fpsc.UseHeadBob = false;
            eh.PlayerOnElevator = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            fpsc.UseHeadBob = true;
            eh.PlayerOnElevator = false;
        }
    }
}
