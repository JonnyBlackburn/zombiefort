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

        public void openGUI(string gui, object data = null)
        {
            foreach(GUIBase openView in openViews) 
            {
                if (!openView.isImportant) closeGUI(openView.GetType().Name);
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

        public void ShowNotification(GameEvent gameEvent)
        {
                        
        }
    }
}
