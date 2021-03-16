using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    public class Player:Character
    {
        public Player(int health, int x, int y):base(health)
        {
            X = x;
            Y = y;
            Backpack = new List<ICarryable>();
        }

        public int X { get; set; }
        public int Y { get; set; }

        public List<ICarryable> Backpack { get; set; }
    }
}
