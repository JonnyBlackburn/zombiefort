using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.GUI.Notifications;
using UnityEngine;

namespace Assets.Scripts.GameEvents
{

    public class GameEvent : MonoBehaviour
    {
        public virtual string Title { get; protected set; }
        public virtual string Description { get; protected set; }
        public virtual NotificationButtons NotificationButtons { get { return NotificationButtons.OkCancel; } }

        public virtual GameEventType GameEventType { get; protected set; }

        public virtual bool ShowNotificationOnStart { get { return true; } }

        protected virtual void Start()
        {
            if (ShowNotificationOnStart) GameManager.GetInstance.GuiManager.openGUI("Notification", false, this, true);
        }

        public virtual void Ok()
        {
            
        }

        public virtual void Cancel()
        {

        }

        public virtual void Yes()
        {

        }

        public virtual void No()
        {

        }
    }
}
