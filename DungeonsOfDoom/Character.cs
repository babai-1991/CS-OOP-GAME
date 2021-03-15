using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfDoom
{
    public abstract class Character
    {
        public Character(int health)
        {
            Health = health;
        }
        public int Health { get; set; }

        public bool IsAlive => Health > 0;
    }
}
