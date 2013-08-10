using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.GameEvents;
using UnityEngine;
using Random = System.Random;

namespace Assets.Scripts.Managers
{
    public class GameEventManager : MonoBehaviour
    {
        Random random = new Random();

        private String[] BuildingEvents = {};
        private String[] CombatEvents = {"ZombieHorde"};
        private String[] ResourceEvents = {};
        private String[] CharacterEvents = {"FoundSurvivor"};

        void Start()
        {
        }

        public void StartRandomEvent(GameEventType gameEventType = GameEventType.Any)
        {
            string gameEvent = "";

            switch (gameEventType)
            {
                case GameEventType.Any:
                    var combinedArrays = new List<String>();
                    combinedArrays.AddRange(BuildingEvents);
                    combinedArrays.AddRange(CombatEvents);
                    combinedArrays.AddRange(ResourceEvents);
                    combinedArrays.AddRange(CharacterEvents);
                    gameEvent = combinedArrays.ElementAt(random.Next(combinedArrays.Count));
                    break;
                case GameEventType.BuildingEvent:
                    gameEvent = BuildingEvents[random.Next(BuildingEvents.Length)];
                    break;
                case GameEventType.CharacterEvent:
                    gameEvent = CharacterEvents[random.Next(CharacterEvents.Length)];
                    break;
                case GameEventType.CombatEvent:
                    gameEvent = CombatEvents[random.Next(CombatEvents.Length)];
                    break;
                case GameEventType.ResourceEvent:
                    gameEvent = ResourceEvents[random.Next(ResourceEvents.Length)];
                    break;
            }
            gameObject.AddComponent(gameEvent);
        }

    }
}
