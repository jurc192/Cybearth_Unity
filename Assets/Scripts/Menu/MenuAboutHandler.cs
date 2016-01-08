using UnityEngine;
using System.Collections;

public class MenuAboutHandler : MonoBehaviour {

    [SerializeField] private GameObject bkg;

    void OnMouseEnter()
    {
        bkg.SetActive(true);
    }

    void OnMouseExit()
    {
        bkg.SetActive(false);
    }
}
