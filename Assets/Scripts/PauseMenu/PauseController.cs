using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour {

    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject fpc;

    bool pause = false;

    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;

            if (pause)
            {
                Time.timeScale = 0;
                fpc.SetActive(false);
                Cursor.visible = true;
                pauseMenu.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                fpc.SetActive(true);
                Cursor.visible = false;
                pauseMenu.SetActive(false);
            }
        }    	
	}
}
