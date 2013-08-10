using UnityEngine;
using System.Collections;

public class Resources : MonoBehaviour {

    void OnGUI()
    {
        //GUILayout.BeginArea(new Rect(Screen.width - 200, 0, 200, 100));
        GUILayout.BeginArea(new Rect(0, 0, 200, 200));
        GUILayout.BeginVertical("box");
        GUILayout.Label("Wood: " + GameManager.GetInstance.ResourceManger.wood);
        GUILayout.Label("Metal: " + GameManager.GetInstance.ResourceManger.metal);
        if (GUILayout.Button("Add wood"))
        {
            GameManager.GetInstance.ResourceManger.updateResource(ResourceManager.WOOD, 50);
        }
        if (GUILayout.Button("Add metal"))
        {
            GameManager.GetInstance.ResourceManger.updateResource(ResourceManager.METAL, 50);
        }
        if (GUILayout.Button("Remove wood"))
        {
            GameManager.GetInstance.ResourceManger.updateResource(ResourceManager.WOOD, -50);
        }
        if (GUILayout.Button("Remove metal"))
        {
            GameManager.GetInstance.ResourceManger.updateResource(ResourceManager.METAL, -50);
        }
        GUILayout.EndVertical();
        GUILayout.EndArea();
    }
}
