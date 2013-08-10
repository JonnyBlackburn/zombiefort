using UnityEngine;
using System.Collections;

public class BuildingWindow : GUIBase {

    int width = 400;

	void OnGUI()
    {
        GUILayout.BeginArea(new Rect(Screen.width - width, 0, width, Screen.height));
        GUILayout.Box("", GUILayout.Height(Screen.height));
        if (GUI.Button(new Rect (0, 0, 50, 20), "Close"))
        {
            GameManager.GetInstance.GuiManager.closeGUI(this.GetType().Name);
        }
        GUILayout.EndArea();
    }
}
