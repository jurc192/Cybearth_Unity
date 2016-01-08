using UnityEngine;
using System.Collections;

public class AboutCloseHandler : MonoBehaviour {

    [SerializeField] private GameObject bkg;
    [SerializeField] private GameObject aboutCanvas;

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
        aboutCanvas.SetActive(false);
    }
}
