using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Assets.Scripts.GameEvents;
using Assets.Scripts.GameEvents.BuildingEvent;
using Assets.Scripts.GameEvents.CharacterEvent;
using Assets.Scripts.GameEvents.CombatEvent;
using Assets.Scripts.GameEvents.ResourceEvent;
using UnityEngine;
using Random = System.Random;

namespace Assets.Scripts.Managers
{
    public class GameEventManager : MonoBehaviour
    {
        Random random = new Random();

        void Start()
        {
        }

        public void StartRandomEvent<T>()
        {
            List<String> values = Enum.GetValues(typeof (T)).Cast<String>().ToList();
            gameObject.AddComponent(values.ElementAt(random.Next(values.Count)));
        }

        public void StartRandomEvent()
        {
            List<String> values = new List<String>();
            values.AddRange(Enum.GetValues(typeof (BuildingEvents)).Cast<String>().ToList());
            values.AddRange(Enum.GetValues(typeof (CharacterEvents)).Cast<String>().ToList());
            values.AddRange(Enum.GetValues(typeof (ResourceEvents)).Cast<String>().ToList());
            values.AddRange(Enum.GetValues(typeof (CombatEvents)).Cast<String>().ToList());

            gameObject.AddComponent(values.ElementAt(random.Next(values.Count)));
        }

    }
}
