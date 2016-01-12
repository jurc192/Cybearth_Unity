using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlantBomb : MonoBehaviour {
    [SerializeField] GameObject infoText;
    Text text;

    [SerializeField] GameObject endScreen;

    bool active = false;

    void Start()
    {
        text = infoText.GetComponent<Text>();
    }

    void Update()
    {
        if (active && Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<MeshRenderer>().enabled = true;

            infoText.SetActive(false);
            gameObject.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(finishGame());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            infoText.SetActive(true);
            active = true;
            text.text = "PRESS < E >\nTO PLANT THE BOMB";
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            active = false;
            infoText.SetActive(false);
        }
    }

    IEnumerator finishGame()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(3);
    }
}
