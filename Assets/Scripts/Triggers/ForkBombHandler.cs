using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ForkBombHandler : MonoBehaviour {

    [SerializeField] GameObject infoText;
    [SerializeField] GameController gc;
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
                gc.PickedUpForkBomb();
                infoText.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            infoText.SetActive(true);
            text.text = "PRESS < E >\nTO PICK UP";
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
