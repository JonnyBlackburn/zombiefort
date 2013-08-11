using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour 
{
    public bool isWorkableBuilding = false;
    protected int currentBuildingState = 0;
    public int buildingHealth = 100;
    protected ArrayList scrapCosts = new ArrayList();
    protected ArrayList foodCosts = new ArrayList();
    protected ArrayList waterCosts = new ArrayList();
    protected ArrayList ammoCosts = new ArrayList();
    public GameObject[] buildingPhases;

    public GameObject[] personPositions = new GameObject[0];

    void Start()
    {
        initBuildingCosts();
        initialisePlayerPositions();
    }

    protected virtual void initBuildingCosts()
    {
        scrapCosts.Add(30);
        scrapCosts.Add(100);
        scrapCosts.Add(200);

        foodCosts.Add(30);
        foodCosts.Add(100);
        foodCosts.Add(200);
    }

    public void initialisePlayerPositions()
    {
        Person[] allPeople = GameManager.GetInstance.PeopleManager.getAllPeople();
        if (allPeople.Length == 0) return;
        for (var i = 0; i < allPeople.Length; i++)
        {
            allPeople[i].transform.parent = null;
        }
        foreach(Transform child in transform.FindChild("positioner"))
        {
            Destroy(child.gameObject);
        }
        int currentCount = 0;
        int columns = 5;
        for(int curRow = 0; curRow < 100; curRow++)
        {
            for (int curCol = 0; curCol < columns; curCol++)
            {
                GameObject spawnPos = Instantiate(Resources.Load("positioner"), Vector3.zero, Quaternion.identity) as GameObject;
                spawnPos.transform.parent = transform.FindChild("positioner");
                spawnPos.transform.localPosition = new Vector3(curCol * 1.1f, 0, curRow * 1.1f);
                allPeople[currentCount].transform.position = spawnPos.transform.position;
                allPeople[currentCount].transform.parent = allPeople[currentCount].initialParent = spawnPos.transform;
                currentCount++;
                if (currentCount >= allPeople.Length) return;
            }
        }
    }

    void OnMouseDown()
    {
        GameManager.GetInstance.GuiManager.openGUI("BuildingWindow", true, this);
    }

    public bool isFullyUpgraded()
    {
        if (currentBuildingState >= buildingPhases.Length) return true;
        else return false;
    }

    public bool CanAffordNexPhase()
    {
        ResourceManager resources = GameManager.GetInstance.ResourceManger;
        if (resources.Scrap > (int)scrapCosts[currentBuildingState] && resources.Food > (int)foodCosts[currentBuildingState]) return true;
        else return false;
    }

    public virtual void UpgradeBuilding()
    {
        currentBuildingState++;
        transform.localScale *= 2;
        //play next frame of animation
    }
}
