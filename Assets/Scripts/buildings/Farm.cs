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
        scrapCosts.Add(30);
        scrapCosts.Add(100);
        scrapCosts.Add(200);
            
        foodCosts.Add(30);
        foodCosts.Add(100);
        foodCosts.Add(200);
    }

    public override void AwardResources()
    {
        GameManager.GetInstance.ResourceManger.updateResource(ResourceManager.FOOD, 30);
    }
}
