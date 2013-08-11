using UnityEngine;
using System.Collections;

public class DayManager : MonoBehaviour {

    int dayDuration = 5 * 60; //5 minutes

    void StartDay()
    {
        StartCoroutine("DayTimer");
        GameManager.GetInstance.GameTimer.totalGameSeconds = 21600;
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
    }

    IEnumerator DayTimer()
    {
        yield return new WaitForSeconds(dayDuration);
        StartDay();
    }
}
