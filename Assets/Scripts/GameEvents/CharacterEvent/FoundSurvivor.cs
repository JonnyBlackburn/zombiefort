using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.GUI.Notifications;
using UnityEngine;
using Random = System.Random;

namespace Assets.Scripts.GameEvents.CharacterEvent
{
    public class FoundSurvivor : GameEvent
    {
        private string _Description;
        private GameObject person;

        public override string Title
        {
            get { return "Found a Survivor!"; }
        }

        public override string Description
        {
            get { return _Description; }
        }

        public override GUI.Notifications.NotificationButtons NotificationButtons
        {
            get
            {
                return NotificationButtons.YesNo;
            }
        }

        public override GameEventType GameEventType
        {
            get { return GameEventType.CharacterEvent; }
        }

        public void Start()
        {
            _Description = "A survivor has found your camp! ";
            person = Instantiate(Resources.Load("Person")) as GameObject;
            Random random = new Random();
            person.name = GameManager.GetInstance.PeopleManager.peopleNames.ElementAt(random.Next(GameManager.GetInstance.PeopleManager.peopleNames.Length));
            String status = random.Next(1) == 0 ? "nice" : "shifty";
            _Description += "They're name is " + person.name + " and they look " + status + "! Do you want to let them in?";

            base.Start();
        }

        public override void No()
        {
            Destroy(person);
            GameManager.GetInstance.PeopleManager.updateAllPeople();
            base.No();
        }

        public override void Yes()
        {
            GameManager.GetInstance.PeopleManager.updateAllPeople();
            base.Yes();
        }
    }
}
