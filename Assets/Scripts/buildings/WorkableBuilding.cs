using UnityEngine;
using System.Collections;

public class WorkableBuilding : Building {

    public Person selectedWorker;

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
        }
        selectedWorker = worker;
    }
}
