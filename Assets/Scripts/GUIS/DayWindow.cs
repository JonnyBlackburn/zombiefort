using UnityEngine;
using System.Collections;

public class DayWindow : MonoBehaviour
{

    public GUIStyle logButton;
    public GUIStyle popButton;
    public GUIStyle skipButton;
    public Texture2D background;

    public GUIStyle clock;
    public GUIStyle resources;

	void OnGUI()
	{
		GUILayout.BeginArea(new Rect(Screen.width / 2 - 100, 200, background.width, background.height), background);

		GUILayout.BeginVertical();

        GUILayout.Space(26);

        GUILayout.BeginHorizontal();

        GUILayout.Space(65);

        GUILayout.Label(GameManager.GetInstance.ResourceManger.Food.ToString(), resources);

        GUILayout.Space(100);

        GUILayout.Label(GameManager.GetInstance.ResourceManger.Scrap.ToString(), resources);

        GUILayout.EndHorizontal();

        GUILayout.Space(25);

        GUILayout.BeginHorizontal();

        GUILayout.Space(65);

        GUILayout.Label(GameManager.GetInstance.ResourceManger.Food.ToString(), resources);

        GUILayout.Space(100);

        GUILayout.Label(GameManager.GetInstance.ResourceManger.Scrap.ToString(), resources);

        GUILayout.EndHorizontal();

        GUILayout.Space(12);

        GUILayout.BeginHorizontal();

        GUILayout.Space(50);

		if (GUILayout.Button("",logButton))
		{
			GameManager.GetInstance.DayManager.EndDay();
		}
        
        GUILayout.Space(20);

        if (GUILayout.Button("", popButton))
        {
            GameManager.GetInstance.DayManager.EndDay();
        }

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

        GUILayout.Space(22);

        GUILayout.Label(GameManager.GetInstance.GameTimer.GameTime, clock);

        GUILayout.EndHorizontal();

        GUILayout.Space(20);

        GUILayout.BeginHorizontal();

        GUILayout.Space(45);

        if (GUILayout.Button("", skipButton))
        {
            GameManager.GetInstance.DayManager.EndDay();
        }

        GUILayout.EndHorizontal();

		GUILayout.EndVertical();
		GUILayout.EndArea();
	}
}
