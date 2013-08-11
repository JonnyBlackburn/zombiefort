using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    bool isOpen = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isOpen = !isOpen;
            Time.timeScale = isOpen ? 0 : 1;
        }
    }

    void OnGUI()
    {
        if (isOpen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Exit"))
            {
                Application.Quit();
            }
        }
    }
	
}
