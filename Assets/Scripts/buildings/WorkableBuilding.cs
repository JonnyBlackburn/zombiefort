using UnityEngine;
using System.Collections;

public class WorkableBuilding : Building {

    public Person selectedWorker;

    public virtual void assignWorker(Person worker)
    {
        selectedWorker = worker;
        worker.transform.position = personPositions[0].transform.position;
    }
}
