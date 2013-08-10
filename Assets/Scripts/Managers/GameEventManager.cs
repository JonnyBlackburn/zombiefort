using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.GameEvents;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class GameEventManager : MonoBehaviour
    {

        void Start()
        {
            
        }

        public void AddEventToGameObject<T>(GameObject gameObject) where T : GameEvent
        {
            gameObject.AddComponent<T>();
        }
    }
}
