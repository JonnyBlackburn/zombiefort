using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.GameEvents.CombatEvent
{
    public class ZombieHorde : CombatEvent
    {
        public override string Title
        {
            get { return "Zombie Horde!"; }
        }

        public override string Description
        {
            get { return "Oh no! A Zombie horde has attacked your village!"; }
        }
    }
}
