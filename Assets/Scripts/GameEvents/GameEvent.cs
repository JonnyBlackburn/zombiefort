using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.GameEvents
{

    public class GameEvent : MonoBehaviour
    {
        public virtual string Title { get; set; }
        public virtual string Description { get; private set; }

        public virtual bool ShowNotificationOnStart { get { return true; } }

        void Start()
        {
            if(ShowNotificationOnStart) GameManager.GetInstance.NotificationManager.ShowNotification(this);
        }
    }
}
