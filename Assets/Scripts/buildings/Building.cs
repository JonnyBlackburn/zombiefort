using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour 
{
    public bool isWorkableBuilding = false;
    int currentBuildingState = 0;
    public int buildingHealth = 100;
    protected ArrayList woodCosts = new ArrayList();
    protected ArrayList metalCosts = new ArrayList();

    public GameObject[] personPositions = new GameObject[0];

    void Start()
    {
        initBuildingCosts();
        initialisePlayerPositions();
    }

    protected virtual void initBuildingCosts()
    {
        woodCosts.Add(30);
        woodCosts.Add(100);
        woodCosts.Add(200);

        metalCosts.Add(30);
        metalCosts.Add(100);
        metalCosts.Add(200);
    }

    void initialisePlayerPositions()
    {
        int totalPlayerCount = GameManager.GetInstance.PeopleManager.getAllPeople().Length;
        int columns = 5;
        int row = 0;
        for (int curCol = 0; curCol < columns; curCol++)
        {
            //GameObject spawnPos = Instantiate(Resources.)
        }
    }

    void OnMouseDown()
    {
        GameManager.GetInstance.GuiManager.openGUI("BuildingWindow", true, this);
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
        transform.localScale *= 2;
        //play next frame of animation
    }
}
