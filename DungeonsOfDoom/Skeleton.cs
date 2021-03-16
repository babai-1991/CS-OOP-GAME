using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfDoom
{
    class Skeleton : Monster
    {
        public Skeleton(int health = 5) : base(health)
        {
        }

        public override void Attack(Character opponent)
        {
            if (opponent.Health < 30)
            {
                opponent.Health -= 5;
            }
        }
    }
}
