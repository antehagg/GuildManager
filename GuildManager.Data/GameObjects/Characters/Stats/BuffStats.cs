using System;
using System.Collections.Generic;
using System.Text;

namespace GuildManager.Data.GameObjects.Characters.Stats
{
    public class BuffStats
    {
        public int Strength { get; set; }
        public int Stamina { get; set; }
        public int Agility { get; set; }
        public int Wisdom { get; set; }
        public int Intelligence { get; set; }

        public double Haste { get; set; }
        public double CritChance { get; set; }

        public int Health { get; set; }
        public int Energy { get; set; }
        public int Armor { get; set; }
    }
}
