using Assets.Scripts.GUI.Notifications;
using Assets.Scripts.GameEvents;
using UnityEngine;

namespace Assets.Scripts.GUIS.Notifications
{
    public class Notification : GUIBase
    {
        public GameEvent GameEvent;
        private float width;

        public override void openView(object data)
        {
            GameEvent = data as GameEvent;
        }

        void OnGUI()
        {
            width = Screen.width * 0.35f;
            GUILayout.BeginArea(new Rect(Screen.width - width, 0, width, Screen.height));
            //GUILayout.Box("", GUILayout.Height(Screen.height));
            GUILayout.BeginVertical("box", GUILayout.Height(Screen.height));
            GUILayout.Label(GameEvent.Title);
            GUILayout.Label(GameEvent.Description);
            GUILayout.Box(GameEvent.Icon);
            switch (GameEvent.NotificationButtons)
            {
                case NotificationButtons.Ok:
                    if (GUILayout.Button("Ok"))
                    {
                        GameEvent.Ok();
                        Close();
                    }
                    break;
                case NotificationButtons.OkCancel:
                    if (GUILayout.Button("Ok"))
                    {
                        GameEvent.Ok();
                        Close();
                    }
                    if (GUILayout.Button("Cancel"))
                    {
                        GameEvent.Cancel();
                        Close();
                    }
                    break;
                case NotificationButtons.YesNo:
                    if (GUILayout.Button("Yes"))
                    {
                        GameEvent.Yes();
                        Close();
                    }
                    if (GUILayout.Button("No"))
                    {
                        GameEvent.No();
                        Close();
                    }
                    break;
            }

            GUILayout.EndVertical();
            GUILayout.EndArea();
        }

        private void CreateWindow(int id)
        {

        }
    }
}
