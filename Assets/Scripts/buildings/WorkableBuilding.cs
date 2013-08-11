using UnityEngine;
using System.Collections;

public class WorkableBuilding : Building {

    public Person selectedWorker;

    void Start()
    {
        currentBuildingState--;
    }

    protected override void initBuildingCosts()
    {
        scrapCosts.Add(30);
        scrapCosts.Add(200);
        scrapCosts.Add(300);

        foodCosts.Add(30);
        foodCosts.Add(100);
        foodCosts.Add(200);
    }

    public virtual void assignWorker(Person worker)
    {
        if (worker != null)
        {
            if (selectedWorker != null)
            {
                selectedWorker.transform.parent = selectedWorker.initialParent;
                selectedWorker.transform.position = selectedWorker.initialParent.position;
            }
            worker.transform.position = personPositions[0].transform.position;
            worker.transform.parent = personPositions[0].transform;
        }
        else
        {
            selectedWorker.transform.parent = selectedWorker.initialParent;
            selectedWorker.transform.localPosition = Vector3.zero;
            selectedWorker.isAssignedToBuilding = false;
            selectedWorker.animation.Play("HumanBuilding");
        }
        selectedWorker = worker;
    }

    public override void UpgradeBuilding()
    {
        if (currentBuildingState >= buildingPhases.Length) return;
        buildingPhases[currentBuildingState].SetActive(true);
        currentBuildingState++;
    }
}
