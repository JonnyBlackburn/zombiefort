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
                t.IsClass && t.BaseType == typeof(GameEvent)
                && Attribute.IsDefined(t, typeof(SerializableAttribute))).Cast<GameEvent>().ToList();
        }

        public void StartRandomEvent(GameEventType gameEventType = GameEventType.Any)
        {
            List<GameEvent> filteredGameEvents = GameEvents;

            if (gameEventType != GameEventType.Any)
            {
                filteredGameEvents = filteredGameEvents.Where(t => t.GetType().ToString() == gameEventType.ToString()).ToList();
            }

            gameObject.AddComponent(GetRandomGameEvent(filteredGameEvents).GetType().ToString());
        }

        private GameEvent GetRandomGameEvent(List<GameEvent> gameEvents)
        {
            Random random = new Random();
            return gameEvents[random.Next(gameEvents.Count)];
        }

    }
}
