using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.GameEvents
{

    public class GameEvent : MonoBehaviour
    {
        public string Title { get; private set; }
        public string Description { get; private set; }

        void Start()
        {
            GameManager.GetInstance.NotificationManager.ShowNotification(this);
        }
    }
}
