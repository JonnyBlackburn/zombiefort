using UnityEngine;
using System.Collections;

public class PeopleManager : MonoBehaviour
{
    private Person[] allPeople;

    void Start()
    {
        updateAllPeople();
    }

    public void updateAllPeople()
    {
        allPeople = getAllPeople();
    }

    public Person[] getAllPeople()
    {
        return GameObject.FindObjectsOfType(typeof(Person)) as Person[];
    }

    public GameObject Spawn(string resourceName, Vector3 position, Quaternion rotation)
    {
        GameObject gameObject = Instantiate(Resources.Load(resourceName), position, rotation) as GameObject;
        updateAllPeople();
        return gameObject;
    }

    public Person[] getAllNonWorkingPeople()
    {
        ArrayList tempPeopleList = new ArrayList();
        foreach (Person person in allPeople)
        {
            if (!person.isAssignedToBuilding) tempPeopleList.Add(person);
        }
        Person[] returnPeople = new Person[tempPeopleList.Count];
        for (int i = 0; i < returnPeople.Length; i++)
        {
            returnPeople[i] = tempPeopleList[i] as Person;
        }
        return returnPeople;
    }
}
