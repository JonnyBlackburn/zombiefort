using UnityEngine;
using System.Collections;

public class PeopleManager : MonoBehaviour {

    Person[] allPeople = new Person[0];

    void Start()
    {
        updateAllPeople();
    }

    public void updateAllPeople()
    {
        allPeople = getAllPeople();
    }

    Person[] getAllPeople()
    {
        return GameObject.FindObjectsOfType(typeof(Person)) as Person[];
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
