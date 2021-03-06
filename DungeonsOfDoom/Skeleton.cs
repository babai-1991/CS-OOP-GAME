using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfDoom
{
    class Skeleton : Monster
    {
        public Skeleton(int health = 5) : base("Skeleton",health)
        {
        }

        public override AttackResult  Attack(Character opponent)
        {
            int damage = 0;
            if (opponent.Health < 30)
            {
                damage = 5;
                opponent.Health -= damage;
            }
            return new AttackResult(this,opponent,damage);
        }
    }
}
