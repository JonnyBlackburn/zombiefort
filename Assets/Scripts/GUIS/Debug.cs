using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.GameEvents.CombatEvent;
using UnityEngine;

namespace Assets.Scripts.GUIS
{
    public class Debug : MonoBehaviour
    {
        void OnGUI()
        {
            //GUILayout.BeginArea(new Rect(Screen.width - 200, 0, 200, 100));
            GUILayout.BeginArea(new Rect(Screen.width / 2 - 100, Screen.height - 200, 200, 200));
            GUILayout.BeginVertical("Box");
            if (GUILayout.Button("Start Event"))
            {
                GameManager.GetInstance.GameEventManager.StartRandomEvent();
            }
            GUILayout.EndVertical();
            GUILayout.EndArea();
        }
    }
}
