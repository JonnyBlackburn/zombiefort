using UnityEngine;
using System.Collections;

public class MainMenuGUI : MonoBehaviour {

    private enum MenuStates { main, credits };
    private MenuStates state = MenuStates.main;
    public Texture2D background;

	void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), background);
        if (state == MenuStates.main) mainScreen();
        if (state == MenuStates.credits) creditsScreen();
    }

    void mainScreen()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height - 150, 100, 50), "Start"))
        {
            Application.LoadLevel(1);
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height - 100, 100, 50), "Credits"))
        {
            state = MenuStates.credits;
        }
    }

    void creditsScreen()
    {
        GUILayout.BeginArea(new Rect(Screen.width / 2 - 200, Screen.height - 300, 400, 300));
        GUILayout.BeginVertical();
        GUILayout.Label("Phil 'Mothphil' Allcock");
        GUILayout.Label("Andrew 'smells' Munro");
        GUILayout.Label("Edward 'ZX5' Everett");
        GUILayout.Label("Jonny 'your mum' Blackburn");
        if (GUILayout.Button("Back"))
        {
            state = MenuStates.main;
        }
        GUILayout.EndVertical();
        GUILayout.EndArea();
    }
}
