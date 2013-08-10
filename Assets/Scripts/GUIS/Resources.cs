using UnityEngine;
using System.Collections;

public class Resources : MonoBehaviour {

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(Screen.width - 200, 0, 200, 100));
        GUILayout.BeginVertical("box");
        GUILayout.Label("Wood: " + GameManager.GetInstance.resourceManger.wood);
        GUILayout.Label("Metal: " + GameManager.GetInstance.resourceManger.metal);
        GUILayout.EndVertical();
        GUILayout.EndArea();
    }
}
