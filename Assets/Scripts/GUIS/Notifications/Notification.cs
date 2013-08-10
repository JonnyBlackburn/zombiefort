using Assets.Scripts.GUI.Notifications;
using UnityEngine;

namespace Assets.Scripts.GUIComponents.Notifications
{
    public class Notification : GUIBase
    {
        public string Title;
        public string Body;
        public Texture2D ImageType;
        public NotificationButtons NotificationButtons;

        private Rect windowRect;
        private Vector2 scrollPosition = Vector2.zero;

        void OnGUI()
        {
            windowRect = GUILayout.Window(0, windowRect, CreateWindow, Title ?? "Undefined");
        }

        void Awake()
        {
            windowRect = new Rect(Screen.width / 2 - 150, 150, 300, 100);
            isImportant = true;
        }

        private void CreateWindow(int id)
        {
            GUILayout.TextArea(Body ?? "Undefined", 200);
            GUILayout.Box(ImageType);
            switch (NotificationButtons)
            {
                case NotificationButtons.Ok:
                    if(GUILayout.Button("Ok"))
                    {
                        Close();
                    }
                    break;
                case NotificationButtons.OkCancel:
                    if(GUILayout.Button("Ok"))
                    {
                        Close();
                    }
                    if (GUILayout.Button("Cancel"))
                    {
                        Close();
                    }
                    break;
            }
        }
    }
}
