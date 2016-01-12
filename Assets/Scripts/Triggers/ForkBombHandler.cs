using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ForkBombHandler : MonoBehaviour {

    [SerializeField] GameObject infoText;
    [SerializeField] GameController gc;
    Text text;

    bool active = false;

    void Start()
    {
        text = infoText.GetComponent<Text>();
    }

    void Update()
    {
        if (active && Input.GetKeyDown(KeyCode.E))
        {
            infoText.SetActive(false);
            gameObject.SetActive(false);
            gc.PickedUpForkBomb();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            infoText.SetActive(true);
            active = true;
            text.text = "PRESS < E >\nTO PICK UP";
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            infoText.SetActive(false);
            active = false;
        }
    }
}
