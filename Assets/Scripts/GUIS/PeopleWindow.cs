using UnityEngine;
using System.Collections;

public class PeopleWindow : GUIBase 
{
    float width = 400;
    Vector2 scrollPosition;

    void OnGUI()
    {
        width = Screen.width * 0.35f;
        GUILayout.BeginArea(new Rect(0, 0, width, Screen.height));
        GUILayout.BeginVertical("box", GUILayout.Height(Screen.height));
        if (GUILayout.Button("close", GUILayout.Width(50)))
        {
            GameManager.GetInstance.GuiManager.closeGUI(this.GetType().Name);
        }

        scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(width), GUILayout.Height(250));
            for (int i = 0; i < GameManager.GetInstance.PeopleManager.getAllNonWorkingPeople().Length; i++ )
            {
                Person person = GameManager.GetInstance.PeopleManager.getAllNonWorkingPeople()[i];
                if (GUILayout.Button(person.name))
                {
                    BuildingWindow buildingWindow = GameManager.GetInstance.GuiManager.GetOpenView("BuildingWindow") as BuildingWindow;
                    buildingWindow.assignWorker(person);
                }
            }
        GUILayout.EndScrollView();

        GUILayout.EndVertical();
        GUILayout.EndArea();
    }
}
