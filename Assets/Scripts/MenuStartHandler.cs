using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuStartHandler : MonoBehaviour {
    [SerializeField] private GameObject bkg;

    void OnMouseEnter()
    {
        bkg.SetActive(true);
    }

    void OnMouseExit()
    {
        bkg.SetActive(false);
    }

    void OnMouseDown()
    {
        SceneManager.LoadScene(1);
    }
}
