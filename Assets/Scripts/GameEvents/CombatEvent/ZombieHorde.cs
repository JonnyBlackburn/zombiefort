using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.GameEvents.CombatEvent
{
    public class ZombieHorde : GameEvent
    {
        public override string Title
        {
            get { return "Zombie Horde!"; }
        }

        public override string Description
        {
            get { return "Oh no! A Zombie horde has attacked your village!"; }
        }

        public override GameEventType GameEventType
        {
            get { return GameEventType.CombatEvent; }
        }

        protected override void Start()
        {
            GameObject zombie = GameManager.GetInstance.PeopleManager.Spawn("Zombie", new Vector3(36, 2, -7), Quaternion.identity);
            //Camera.main.transform.LookAt(zombie.transform.position);
            Debug.Log("Spawned Zombie!");
            

            base.Start();
        }
    }
}
