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
        private List<Type> GameEvents;

        void Start()
        {
            GameEvents = typeof(GameEvent).Assembly.GetTypes().Where(t =>
                t.IsClass && t.BaseType == typeof(GameEvent)
                && Attribute.IsDefined(t, typeof(SerializableAttribute))).ToList();
        }

        public void StartEvent(Type gameEventType = null)
        {
            if (gameEventType != null)
            {
                
            }
        }

        public void AddEventToGameObject<T>(GameObject gameObject) where T : GameEvent
        {
            gameObject.AddComponent<T>();
        }

        private List<T> GetGameEventsByType<T>() where T : GameEvent
        {
            return GameEvents.OfType<T>().ToList();
        }

        private GameEvent GetGameEventByRandom(List<Type> gameEvents)
        {
            Random randNum = new Random();
            GameEvent gameEvent = (GameEvent) gameEvents[randNum.Next(gameEvents.Count)];
        }
    }
}
