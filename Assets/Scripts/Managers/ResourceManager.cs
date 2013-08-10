using UnityEngine;
using System.Collections;

public class ResourceManager : MonoBehaviour {

    public const string FOOD = "food";
    public const string WATER = "water";
    public const string SCRAP = "scrap";
    public const string AMMO = "ammo";

    public int Food { get; private set; }
    public int Water { get; private set; }
    public int Scrap { get; private set; }
    public int Ammo { get; private set; }

    void Start()
    {
        //set initial resources
        Food = 200;
        Water = 0;
        Scrap = 0;
        Ammo = 0;
    }

    public void updateResource(string type, int amount)
    {
        switch(type)
        {
            case FOOD:
                Food += amount;
                break;
            case WATER:
                Water += amount;
                break;
            case SCRAP:
                Scrap += amount;
                break;
            case AMMO:
                Ammo += amount;
                break;
        }
    }
}
