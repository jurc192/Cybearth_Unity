using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnterDoorHandler : MonoBehaviour {
    [SerializeField] GameObject infoText;
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
            SceneManager.LoadScene(2);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            infoText.SetActive(true);
            active = true;
            text.text = "PRESS < E >\nTO ENTER";
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
