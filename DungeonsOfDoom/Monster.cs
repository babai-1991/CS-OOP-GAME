using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    public abstract class Monster:Character,ICarryable
    {
        protected Monster(string name,int health):base(health)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
