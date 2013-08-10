using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.GameEvents
{

    public class GameEvent : MonoBehaviour
    {
        void Start()
        {
            GameManager.GetInstance.NotificationManager.ShowNotification();
        }
    }
}
