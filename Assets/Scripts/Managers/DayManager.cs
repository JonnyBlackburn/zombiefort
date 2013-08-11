using UnityEngine;
using System.Collections;

public class DayManager : MonoBehaviour {

    int dayDuration = 5 * 60; //5 minutes
    public double totalGameSeconds = 0; // Start at 6 hours
    public double seconds;
    public double minutes;
    public double hours;
    private double secondsPerSecond = 288; //5 minutes day.

    public string GameTime
    {
        get
        {
            Debug.Log(hours % 24 + ":" + minutes % 60);
            return hours % 24 + ":" + minutes % 60;
        }
    }

    void Update()
    {
        totalGameSeconds += secondsPerSecond * Time.deltaTime;
        seconds = totalGameSeconds;
        minutes = totalGameSeconds / 60;
        hours = minutes / 60;
    }


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
