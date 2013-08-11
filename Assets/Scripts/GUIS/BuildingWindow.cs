using UnityEngine;
using System.Collections;

public class BuildingWindow : GUIBase {

    float width;
    Building selectedBuilding;

    public override void openView(object data)
    {
        selectedBuilding = data as Building;
    }

	void OnGUI()
    {
        width = Screen.width * 0.35f;
        GUILayout.BeginArea(new Rect(Screen.width - width, 0, width, Screen.height * 0.5f));
        GUILayout.BeginVertical("box", GUILayout.Height(Screen.height));
        if (GUILayout.Button("close", GUILayout.Width(50)))
        {
            GameManager.GetInstance.GuiManager.closeGUI(this.GetType().Name);
            if (GameManager.GetInstance.GuiManager.hasOpenView("PeopleWindow")) GameManager.GetInstance.GuiManager.closeGUI("PeopleWindow");

        }
        if (selectedBuilding)
        {
            if (selectedBuilding.isWorkableBuilding) WorkableBuildingGUI();
            else GeneralBuildingGui();
        }
        
        GUILayout.EndVertical();
        GUILayout.EndArea();
    }

    void WorkableBuildingGUI()
    {
        GeneralBuildingGui();
        WorkableBuilding building = selectedBuilding as WorkableBuilding;
        if (!building.selectedWorker)
        {
            if (GUILayout.Button("Assign person"))
            {
                GameManager.GetInstance.GuiManager.openGUI("PeopleWindow", false);
            }
        }
        else
        {
            GUILayout.BeginHorizontal();
            GUILayout.Box(building.selectedWorker.name);
            if (GUILayout.Button("Unassign person"))
            {
                 building.assignWorker(null);
            }
            GUILayout.EndHorizontal();
        }
    }

    void GeneralBuildingGui()
    {
        if (selectedBuilding.isFullyUpgraded())
        {
            GUILayout.Box("Building fully upgraded");
        }
        else if (selectedBuilding.CanAffordNexPhase())
        {
            if (GUILayout.Button("Upgrade"))
            {
                selectedBuilding.UpgradeBuilding();
            }
        }
        else
        {
            GUILayout.Box("Can't afford upgrade");
        }
        GUILayout.Label("Building's health: " + selectedBuilding.buildingHealth);
    }

    public void assignWorker(Person person)
    {
        WorkableBuilding building = selectedBuilding as WorkableBuilding;
        if (building.selectedWorker)
        {
            building.selectedWorker.isAssignedToBuilding = false;
        }
        building.assignWorker(person);
        person.isAssignedToBuilding = true;
    }
}
