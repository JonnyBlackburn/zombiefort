using UnityEngine;
using System.Collections;

public class ResourceManager : MonoBehaviour {

    public const string WOOD = "wood";
    public const string METAL = "metal";

    public int wood { get; private set; }
    public int metal { get; private set; }

    void Start()
    {
        //set initial resources
        wood = 200;
        metal = 0;
    }

    public void updateResource(string type, int amount)
    {
        switch(type)
        {
            case METAL:
                metal += amount;
                break;
            case WOOD:
                wood += amount;
                break;
            default:
                break;
        }
    }
}
