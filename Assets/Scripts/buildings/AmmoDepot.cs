using UnityEngine;
using System.Collections;

public class AmmoDepot : WorkableBuilding {

    void Start()
    {
        initBuildingCosts();
    }

    public override void AwardResources()
    {
        GameManager.GetInstance.ResourceManger.updateResource(ResourceManager.SCRAP, 30);
    }
}
