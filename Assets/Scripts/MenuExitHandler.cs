using UnityEngine;
using System.Collections;

public class MenuExitHandler : MonoBehaviour
{
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
        Application.Quit();
    }
}
