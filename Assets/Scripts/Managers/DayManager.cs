using UnityEngine;
using System.Collections;

public class DayManager : MonoBehaviour {

    int dayDuration = 5 * 60; //5 minutes

    public string Time = "00:00";

    void StartDay()
    {
        StartCoroutine("DayTimer");
    }

    public void EndDay()
    {
        StopCoroutine("DayTimer");
        Debug.Log("Fire end of day events");
        GameManager.GetInstance.GameEventManager.StartRandomEvent();
    }

    IEnumerator DayTimer()
    {
        yield return new WaitForSeconds(dayDuration);
        StartDay();
    }
}
