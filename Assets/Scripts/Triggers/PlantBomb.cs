using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlantBomb : MonoBehaviour {
    [SerializeField] GameObject infoText;
    Text text;

    [SerializeField] GameObject endScreen;

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
                GetComponent<MeshRenderer>().enabled = true;

                infoText.SetActive(false);
                gameObject.GetComponent<BoxCollider>().enabled = false;
                StartCoroutine(finishGame());
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            infoText.SetActive(true);
            text.text = "PRESS < E >\nTO PLANT THE BOMB";
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            infoText.SetActive(false);
        }
    }

    IEnumerator finishGame()
    {
        yield return new WaitForSeconds(3f);
        //GameObject.FindGameObjectWithTag("Player").SetActive(false);
        //endScreen.SetActive(true);
        //Time.timeScale = 0;
        //Cursor.visible = true;

        SceneManager.LoadScene(3);
    }
}
