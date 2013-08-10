using UnityEngine;
using System.Collections;

public class PeopleWindow : GUIBase 
{
    int width = 400;
    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(0, 0, width, Screen.height));
        GUILayout.BeginVertical("box", GUILayout.Height(Screen.height));
        if (GUILayout.Button("close", GUILayout.Width(50)))
        {
            GameManager.GetInstance.GuiManager.closeGUI(this.GetType().Name);
        }

        GUILayout.EndVertical();
        GUILayout.EndArea();
    }
}
