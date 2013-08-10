using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {

    void OnMouseDown()
    {
        GameManager.GetInstance.resourceManger.updateResource(ResourceManager.WOOD, -10);
    }
}
