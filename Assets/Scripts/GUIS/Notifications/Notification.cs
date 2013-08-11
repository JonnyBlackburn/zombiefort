using Assets.Scripts.GUI.Notifications;
using Assets.Scripts.GameEvents;
using Assets.Scripts.GameEvents.CombatEvent;
using UnityEngine;

namespace Assets.Scripts.GUIS.Notifications
{
    public class Notification : GUIBase
    {
        public GameEvent GameEvent;
        private float width;

        public GUIStyle yesButton;
        public GUIStyle noButton;
        public GUIStyle okButton;
        public GUIStyle cancelButton;
        public Texture2D background;

        public GUIStyle title;
        public GUIStyle description;

        public Texture2D buildingIcon;
        public Texture2D charIcon;
        public Texture2D combatIcon;
        public Texture2D resourceIcon;
        public Texture2D disasterIcon;


        public override void openView(object data)
        {
            GameEvent = data as GameEvent;
        }

        void OnGUI()
        {
            if (GameEvent == null) return;
            GUILayout.BeginArea(new Rect(Screen.width / 2 - background.width / 2, Screen.height / 2 - background.height / 2, background.width, background.height), background);
            GUILayout.BeginVertical("box", GUILayout.Height(Screen.height));
            GUILayout.Space(25);

            GUILayout.BeginHorizontal();
            GUILayout.Space(25);
            GUILayout.Label(GameEvent.Title, title);
            GUILayout.EndHorizontal();

            GUILayout.Space(20);

            GUILayout.BeginHorizontal();
            GUILayout.Space(20);
            switch (GameEvent.GameEventType)
            {
                case GameEventType.BuildingEvent:
                    GUILayout.Label(buildingIcon);
                    break;
                case GameEventType.CharacterEvent:
                    GUILayout.Label(charIcon);
                    break;
                case GameEventType.CombatEvent:
                    GUILayout.Label(combatIcon);
                    break;
                case GameEventType.ResourceEvent:
                    GUILayout.Label(resourceIcon);
                    break;
                case GameEventType.DisasterEvent:
                    GUILayout.Label(disasterIcon);
                    break;
            }
            GUILayout.Space(10);
            GUILayout.Label(GameEvent.Description, description);
            GUILayout.EndHorizontal();
            GUILayout.Space(40);
            GUILayout.BeginHorizontal();
            switch (GameEvent.NotificationButtons)
            {
                case NotificationButtons.Ok:
                    GUILayout.Space(165);
                    if (GUILayout.Button("", okButton))
                    {
                        GameEvent.Ok();
                        Close();
                    }
                    break;
                case NotificationButtons.OkCancel:
                    GUILayout.Space(50);
                    if (GUILayout.Button("", okButton))
                    {
                        GameEvent.Ok();
                        Close();
                    }
                    GUILayout.Space(25);
                    if (GUILayout.Button("", cancelButton))
                    {
                        GameEvent.Cancel();
                        Close();
                    }
                    break;
                case NotificationButtons.YesNo:
                    GUILayout.Space(50);
                    if (GUILayout.Button("", yesButton))
                    {
                        GameEvent.Yes();
                        Close();
                    }
                    GUILayout.Space(25);
                    if (GUILayout.Button("", noButton))
                    {
                        GameEvent.No();
                        Close();
                    }
                    break;
            }
            GUILayout.EndHorizontal();

            GUILayout.EndVertical();
            GUILayout.EndArea();
        }

        private void CreateWindow(int id)
        {

        }
    }
}
