using System;
using System.Collections.Generic;
using System.Text;

namespace GuildManager.Server.GameEngine.Helpers.Rng
{
    public static class Dice
    {
        public static int Roll(int min, int max)
        {
            var rnd = new Random();
            return rnd.Next(min, max);
        }
    }
}
