using UnityEngine;
using System.Collections;

public class WaterTreatment : WorkableBuilding
{
    void Start()
    {
        initBuildingCosts();
    }

    public override void AwardResources()
    {
        GameManager.GetInstance.ResourceManger.updateResource(ResourceManager.WATER, 30);
    }
}
