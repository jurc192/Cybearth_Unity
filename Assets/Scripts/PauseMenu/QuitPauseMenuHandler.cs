using UnityEngine;
using System.Collections;

public class QuitPauseMenuHandler : MonoBehaviour {
    [SerializeField] GameObject bkg;

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
        Application.Quit();
    }
}
