using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour {

    [SerializeField] GameObject pauseMenu;

    bool pause = false;

    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;

            if (pause)
            {
                Time.timeScale = 0;
                Cursor.visible = true;
                pauseMenu.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                Cursor.visible = false;
                pauseMenu.SetActive(false);
            }
        }    	
	}
}
