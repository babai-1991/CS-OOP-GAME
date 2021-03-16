using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfDoom
{
    class Health:Item
    {
        public Health(string name="Medkit") : base(name)
        {
        }

        public override void Use(Player player)
        {
            player.Health += 10;
            player.X = 0;
            player.Y = 0;
        }
    }
}
