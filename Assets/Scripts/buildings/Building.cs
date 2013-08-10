using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {

    void OnMouseDown()
    {
        GameManager.GetInstance.ResourceManger.updateResource(ResourceManager.WOOD, -10);
    }
}
