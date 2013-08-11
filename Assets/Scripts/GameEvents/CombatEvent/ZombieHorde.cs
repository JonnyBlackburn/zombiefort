using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Random = System.Random;

namespace Assets.Scripts.GameEvents.CombatEvent
{
    public class ZombieHorde : GameEvent
    {
        private string _Description;
        private Random random;

        public override string Title
        {
            get { return "Zombie Horde!"; }
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
            Instantiate(Resources.Load("Zombie"));

            _Description = "Oh no! Zombies attacked your Village! ";

            random = new Random();
            int randomValue = random.Next(0, 2);
			
			if(GameManager.GetInstance.ResourceManger.Ammo > 0) 
			{
				GameManager.GetInstance.ResourceManger.updateResource(ResourceManager.AMMO, -random.Next(GameManager.GetInstance.ResourceManger.Ammo / 4, GameManager.GetInstance.ResourceManger.Ammo));
			}
			
            switch (randomValue)
            {
                case 0:
                    _Description += "Your defences managed to withstand them and they did no real damage.";
					GiveAmmo();
                    break;
                case 1:
                    KillPerson();
                    break;
                case 2:
                    DamageBuilding();
                    break;
            }
			
            base.Start();
        }

        private void DamageBuilding()
        {
            Building[] buildings = GameManager.GetInstance.GetGameObjectsOfType<Building>();
            Building building = buildings.ElementAt(random.Next(buildings.Length));
            building.buildingHealth -= random.Next(100);
            if (building.buildingHealth <= 0)
            {
                _Description += "They breached your defences and destroyed " + building.name + "!";
                Destroy(building);
            }
            else
            {
                _Description += "They breached your defences and damaged " + building.name + "!";
            }
        }

        private void KillPerson()
        {
            Person[] people = GameManager.GetInstance.GetGameObjectsOfType<Person>();
            if (people.Length == 0) return;
            Person person = people.ElementAt(random.Next(people.Length));
            _Description += "They breached your defences and killed " + person.name + "!";
            Destroy(person);
            GameManager.GetInstance.PeopleManager.updateAllPeople();
        }

		private void GiveAmmo()
		{
			if(random.Next(2) >= 1)
			{
				int ammoAmount = random.Next(1, 10);
				GameManager.GetInstance.ResourceManger.updateResource(ResourceManager.AMMO, ammoAmount);
				_Description += "The zombies dropped " + ammoAmount + " ammo.";
			}
		}
    }
}
