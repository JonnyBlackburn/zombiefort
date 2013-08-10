using UnityEngine;
using System.Collections;

public class Resources : MonoBehaviour {

    void OnGUI()
    {
        //GUILayout.BeginArea(new Rect(Screen.width - 200, 0, 200, 100));
        GUILayout.BeginArea(new Rect(0, 0, 200, 100));
        GUILayout.BeginVertical("box");
        GUILayout.Label("Wood: " + GameManager.GetInstance.ResourceManger.wood);
        GUILayout.Label("Metal: " + GameManager.GetInstance.ResourceManger.metal);
        GUILayout.EndVertical();
        GUILayout.EndArea();
    }
}
