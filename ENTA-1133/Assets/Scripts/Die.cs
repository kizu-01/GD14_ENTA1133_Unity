using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GD14_1133_Lab3_DiceGame_Cadelinia_Demi.Scripts
{
    internal class Die
    {
        // Use a static Random so repeated quick calls don't get same seed
        private static readonly Random rd = new Random();

        // Roll a die with the given sides (1..sides)
        internal int Roll(int sides)
        {
            if (sides < 1) throw new ArgumentException("sides must be >= 1");
            return rd.Next(1, sides + 1);
        }
    }
}
