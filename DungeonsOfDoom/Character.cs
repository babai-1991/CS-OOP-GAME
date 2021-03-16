using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfDoom
{
    public abstract class Character
    {
        protected Character(int health)
        {
            Health = health;
        }

        //damage by ogre player and skeleton
        /*as both ogre and player dealt same damage so this will be default implementation
        skeleton damage dealt 5 so it will override */
        public virtual AttackResult Attack(Character opponent)
        {
            int damage = 10;
            opponent.Health -= damage;
            return new AttackResult(this,opponent,damage);
        }

        public int Health { get; set; }

        public bool IsAlive => Health > 0;
    }
}
