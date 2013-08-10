using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.GameEvents;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class GUIManager : MonoBehaviour
    {
        ArrayList openViews = new ArrayList();

        public void openGUI(string gui, bool closeOpenWindows, object data = null)
        {
            if (closeOpenWindows)
            {
                for(int i = openViews.Count-1; i > 0; i--)
                {
                    GUIBase openView = openViews[i] as GUIBase;
                    if (!openView.isImportant)
                    {
                        closeGUI(openView.GetType().Name);
                    }
                }
            }
            gameObject.AddComponent(gui);
            GUIBase newView = GetComponent(gui) as GUIBase;
            openViews.Add(newView);
            newView.openView(data);
        }

        public void closeGUI(string gui)
        {
            removeViewFromOpen(gui);
            GUIBase guiComponent = GetComponent(gui) as GUIBase;
            guiComponent.Close();
        }

        public bool hasOpenView(string gui)
        {
            foreach (GUIBase openView in openViews)
            {
                if (gui == openView.GetType().Name) return true;
            }
            return false;
        }

        void removeViewFromOpen(string viewName)
        {
            foreach (GUIBase view in openViews)
            {
                if (view.GetType().Name == viewName)
                {
                    openViews.Remove(view);
                    break;
                }
            }
        }

        public GUIBase GetOpenView(string viewName)
        {
            foreach (GUIBase view in openViews)
            {
                if (view.GetType().Name == viewName) return view;
            }
            return null;
        }

        public void ShowNotification(GameEvent gameEvent)
        {
            Debug.Log("Show Notification called for " + gameEvent.Title);
        }
    }
}
