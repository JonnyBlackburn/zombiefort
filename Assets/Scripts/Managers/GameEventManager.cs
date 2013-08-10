using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Assets.Scripts.GameEvents;
using UnityEngine;
using Random = System.Random;

namespace Assets.Scripts.Managers
{
    public class GameEventManager : MonoBehaviour
    {
        private List<GameEvent> GameEvents;

        void Start()
        {
            GameEvents = typeof(GameEvent).Assembly.GetTypes().Where(t => 
                t.IsClass &&
                t.IsSubclassOf(typeof(GameEvent))).Cast<GameEvent>().ToList();
        }

        public void StartEvent(GameEvent gameEvent)
        {
            gameObject.AddComponent(gameEvent.GetType().ToString());
        }

        public void StartRandomEvent(GameEventType gameEventType = GameEventType.Any)
        {
            List<GameEvent> filteredGameEvents = GameEvents;

            if (gameEventType != GameEventType.Any)
            {
                filteredGameEvents = filteredGameEvents.Where(t => t.GetType().ToString() == gameEventType.ToString()).ToList();
            }

            GameEvent gameEvent = GetRandomGameEvent(filteredGameEvents);

            gameObject.AddComponent(gameEvent.GetType().ToString());
        }

        private GameEvent GetRandomGameEvent(List<GameEvent> gameEvents)
        {
            Random random = new Random();
            return gameEvents.ElementAt(random.Next(gameEvents.Count));
        }

    }
}
