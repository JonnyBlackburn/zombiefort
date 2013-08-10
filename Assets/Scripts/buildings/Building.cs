using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour 
{
    int currentBuildingState = 0;
    public int buildingHealth = 100;
    ArrayList woodCosts = new ArrayList();
    ArrayList metalCosts = new ArrayList();

    void Start()
    {
        initBuildingCosts();
    }

    void initBuildingCosts()
    {
        woodCosts.Add(30);
        woodCosts.Add(100);
        woodCosts.Add(200);

        metalCosts.Add(30);
        metalCosts.Add(100);
        metalCosts.Add(200);
    }

    void OnMouseDown()
    {
        //GameManager.GetInstance.ResourceManger.updateResource(ResourceManager.WOOD, -10);
        GameManager.GetInstance.GuiManager.openGUI("BuildingWindow", this);
    }

    public bool CanAffordNexPhase()
    {
        ResourceManager resources = GameManager.GetInstance.ResourceManger;
        if (resources.wood > (int)woodCosts[currentBuildingState] && resources.metal > (int)metalCosts[currentBuildingState]) return true;
        else return false;
    }

    public void UpgradeBuilding()
    {
        currentBuildingState++;
        //play next frame of animation
    }
}
