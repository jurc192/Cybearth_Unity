using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GoToMainMenu : MonoBehaviour {
    [SerializeField]
    GameObject bkg;

    void Start()
    {
        Cursor.visible = true;
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
        SceneManager.LoadScene(0);
    }
}
