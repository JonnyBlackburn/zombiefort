using UnityEngine;
using System.Collections;

public class DayWindow : MonoBehaviour {

	void OnGUI()
    {
        GUILayout.BeginArea(new Rect(Screen.width / 2 - 100, 200, 200, 100));
        GUILayout.BeginVertical();
        if (GUILayout.Button("End day"))
        {
            GameManager.GetInstance.DayManager.EndDay();
        }
        GUILayout.EndVertical();
        GUILayout.EndArea();
    }
}
