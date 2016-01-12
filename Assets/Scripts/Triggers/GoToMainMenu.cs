using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GoToMainMenu : MonoBehaviour {
    [SerializeField]
    GameObject bkg;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void OnMouseEnter()
    {
        bkg.SetActive(true);
    }

    public void OnMouseExit()
    {
        bkg.SetActive(false);
    }

    public void OnMouseDown()
    {
        //Application.Quit();
        SceneManager.LoadScene(0);
    }
}
