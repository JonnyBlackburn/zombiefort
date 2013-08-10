using UnityEngine;
using System.Collections;

public class GameResourcesWindow : MonoBehaviour {

    void OnGUI()
    {
        //GUILayout.BeginArea(new Rect(Screen.width - 200, 0, 200, 100));
        GUILayout.BeginArea(new Rect(Screen.width / 2 - 100, 0, 200, 200));
        GUILayout.BeginVertical("box");
        GUILayout.Label("Water: " + GameManager.GetInstance.ResourceManger.Water);
        GUILayout.Label("Scrap: " + GameManager.GetInstance.ResourceManger.Scrap);
        GUILayout.Label("Food: " + GameManager.GetInstance.ResourceManger.Food);
        GUILayout.Label("Ammo: " + GameManager.GetInstance.ResourceManger.Ammo);
        if (GUILayout.Button("Add Water"))
        {
            GameManager.GetInstance.ResourceManger.updateResource(ResourceManager.WATER, 50);
        }
        if (GUILayout.Button("Add Scrap"))
        {
            GameManager.GetInstance.ResourceManger.updateResource(ResourceManager.SCRAP, 50);
        }
        if (GUILayout.Button("Add Food"))
        {
            GameManager.GetInstance.ResourceManger.updateResource(ResourceManager.FOOD, 50);
        }
        if (GUILayout.Button("Add Ammo"))
        {
            GameManager.GetInstance.ResourceManger.updateResource(ResourceManager.AMMO, 50);
        }
        if (GUILayout.Button("Remove Water"))
        {
            GameManager.GetInstance.ResourceManger.updateResource(ResourceManager.WATER, -50);
        }
        if (GUILayout.Button("Remove Scrap"))
        {
            GameManager.GetInstance.ResourceManger.updateResource(ResourceManager.SCRAP, -50);
        }
        if (GUILayout.Button("Add Food"))
        {
            GameManager.GetInstance.ResourceManger.updateResource(ResourceManager.FOOD, 50);
        }
        if (GUILayout.Button("Add Ammo"))
        {
            GameManager.GetInstance.ResourceManger.updateResource(ResourceManager.AMMO, 50);
        }
        GUILayout.EndVertical();
        GUILayout.EndArea();
    }
}
