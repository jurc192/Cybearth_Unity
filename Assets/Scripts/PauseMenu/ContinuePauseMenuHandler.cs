using UnityEngine;
using System.Collections;

public class ContinuePauseMenuHandler : MonoBehaviour {
    [SerializeField] GameObject bkg;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject fpc;

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
        fpc.SetActive(true);
        Cursor.visible = false;
        menu.SetActive(false);
    }
}
