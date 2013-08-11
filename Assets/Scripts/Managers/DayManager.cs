using UnityEngine;
using System.Collections;

public class DayManager : MonoBehaviour {

    int dayDuration = 5 * 60; //5 minutes

    private DayNightController dayNightController;

    void Start()
    {
        dayNightController = GameManager.GetInstance.GetGameObjectsOfType<DayNightController>()[0];
    }

    void StartDay()
    {
        StartCoroutine("DayTimer");
        GameManager.GetInstance.GameTimer.totalGameSeconds = 21600;
        dayNightController.currentCycleTime = 0;
    }

    public void EndDay()
    {
        StopCoroutine("DayTimer");
        WorkableBuilding[] buildings = GameObject.FindObjectsOfType(typeof(WorkableBuilding)) as WorkableBuilding[];
        foreach (WorkableBuilding building in buildings)
        {
            if (building.selectedWorker != null)
            {
                building.AwardResources();
            }
        }
        GameManager.GetInstance.GameEventManager.StartRandomEvent();
        GameManager.GetInstance.GameTimer.totalGameSeconds = 75600; //21:00
        dayNightController.currentCycleTime = (float)(dayNightController.dayCycleLength * 0.75);
    }

    IEnumerator DayTimer()
    {
        yield return new WaitForSeconds(dayDuration);
        StartDay();
    }
}
