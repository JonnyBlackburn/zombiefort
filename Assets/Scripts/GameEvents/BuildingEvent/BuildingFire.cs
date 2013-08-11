using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Random = System.Random;

namespace Assets.Scripts.GameEvents.BuildingEvent
{
    public class BuildingFire : GameEvent
    {
        private string _Description;
        private Random random;

        public override string Title
        {
            get { return "Fire!"; }
        }

        public override string Description
        {
            get { return _Description; }
        }

        public override GameEventType GameEventType
        {
            get { return GameEventType.CombatEvent; }
        }

        protected override void Start()
        {
            _Description = "Oh no! There was a fire";

            DamageBuilding();

            base.Start();
        }

        private void DamageBuilding()
        {
			random = new Random();
			
            Building[] buildings = GameManager.GetInstance.GetGameObjectsOfType<Building>();
            Building building = buildings.ElementAt(random.Next(buildings.Length));
            building.buildingHealth -= random.Next(100);
            if (building.buildingHealth <= 0)
            {
                _Description += " and the " + building.name + " was destroyed!";
                Destroy(building);
            }
            else
            {
                _Description += ". It damaged the " + building.name + ".";
            }
        }
    }
}
