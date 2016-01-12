using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SecondaryElevatorPanelHandler : MonoBehaviour {

    [SerializeField] ElevatorHandler eh;
    [SerializeField] GameObject infoText;
    Text text;

    void Start()
    {
        text = infoText.GetComponent<Text>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                eh.CallElevator();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            infoText.SetActive(true);
            text.text = "PRESS < E >\nTO CALL FOR ELEVATOR";
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            infoText.SetActive(false);
        }
    }

}
