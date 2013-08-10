using UnityEngine;
using System.Collections;

public class BuildingWindow : GUIBase {

    int width = 400;
    Building selectedBuilding;
    Person selectedWorker;

    public override void openView(object data)
    {
        selectedBuilding = data as Building;
    }

	void OnGUI()
    {
        GUILayout.BeginArea(new Rect(Screen.width - width, 0, width, Screen.height));
        //GUILayout.Box("", GUILayout.Height(Screen.height));
        GUILayout.BeginVertical("box", GUILayout.Height(Screen.height));
        if (GUILayout.Button("close", GUILayout.Width(50)))
        {
            GameManager.GetInstance.GuiManager.closeGUI(this.GetType().Name);
        }
        if (selectedBuilding.isWorkableBuilding) WorkableBuildingGUI();
        else NonWorkableBuildingGUI();
        
        GUILayout.EndVertical();
        GUILayout.EndArea();
    }

    void WorkableBuildingGUI()
    {
        if (!selectedWorker)
        {
            if (GUILayout.Button("Assign person"))
            {
                GameManager.GetInstance.GuiManager.openGUI("PeopleWindow", false);
            }
        }
        else
        {
            GUILayout.Box(selectedWorker.name);
        }
    }

    void NonWorkableBuildingGUI()
    {
        if (selectedBuilding.CanAffordNexPhase())
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
        selectedWorker = person;
        person.isAssignedToBuilding = true;
    }
}
