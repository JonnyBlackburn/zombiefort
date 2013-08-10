using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {

    int currentBuildingState;

    void OnMouseDown()
    {
        //GameManager.GetInstance.ResourceManger.updateResource(ResourceManager.WOOD, -10);
        GameManager.GetInstance.GuiManager.openGUI("BuildingWindow");
    }
}
