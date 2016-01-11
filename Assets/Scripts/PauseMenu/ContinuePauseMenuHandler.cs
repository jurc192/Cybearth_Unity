using UnityEngine;
using System.Collections;

public class ContinuePauseMenuHandler : MonoBehaviour {
    [SerializeField] GameObject bkg;
    [SerializeField] GameObject menu;

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
        Time.timeScale = 1;
        Cursor.visible = false;
        menu.SetActive(false);
    }
}
