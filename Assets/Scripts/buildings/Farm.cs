using UnityEngine;
using System.Collections;

public class Farm : WorkableBuilding {

	void Start()
	{
		buildingHealth = 20;
        isWorkableBuilding = true;
        initBuildingCosts();
	}

    protected override void initBuildingCosts()
    {
        woodCosts.Add(30);
        woodCosts.Add(100);
        woodCosts.Add(200);

        metalCosts.Add(30);
        metalCosts.Add(100);
        metalCosts.Add(200);
    }
}
