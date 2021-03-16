using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfDoom
{
    public class AttackResult
    {
        public AttackResult(Character attacker, Character opponent, int damageDealt)
        {
            Attacker = attacker;
            Opponent = opponent;
            DamageDealt = damageDealt;
        }

        public Character Attacker { get; set; }
        public Character Opponent { get; set; }
        public int DamageDealt { get; set; }
    }
}

