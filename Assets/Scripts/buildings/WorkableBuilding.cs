﻿using UnityEngine;
using System.Collections;

public class WorkableBuilding : Building {

    public Person selectedWorker;

    public virtual void assignWorker(Person worker)
    {
        if (worker != null)
        {
            worker.transform.position = personPositions[0].transform.position;
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
