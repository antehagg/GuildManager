using System;
using System.Collections.Generic;
using System.Text;

namespace GuildManager.Data.GameObjects.Stats
{
    public class PlayerStats
    {
        public Stat Strength { get; set; }
        public Resource Health { get; set; }

        public PlayerStats(int baseStr, int baseHp)
        {
            CalculateStats(baseStr);
            CalculateResources(baseHp);
        }

        private void CalculateStats(int baseStr)
        {
            Strength = new Stat(baseStr, 0, 0);
        }

        private void CalculateResources(int baseHp)
        {
            Health = new Resource(baseHp, 0, 0, Strength.MaxValue);
        }
    }
}
