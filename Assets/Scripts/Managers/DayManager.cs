using UnityEngine;
using System.Collections;

public class DayManager : MonoBehaviour {

    int dayDuration = 5 * 60; //5 minutes

    void StartDay()
    {
        StartCoroutine("DayTimer");
    }

    public void EndDay()
    {
        StopCoroutine("DayTimer");
        Debug.Log("Fire end of day events");
    }

    IEnumerator DayTimer()
    {
        yield return new WaitForSeconds(dayDuration);
        StartDay();
    }
}
