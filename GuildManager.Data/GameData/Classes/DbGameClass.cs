﻿using System.Collections.Generic;
using GuildManager.Data.GameData.Abilities;
using GuildManager.Data.GameData.Classes.GameClassData;

namespace GuildManager.Data.GameData.Classes
{
    public class DbGameClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public BaseStats BaseStats { get; set; }
        public BaseResources BaseResources { get; set; }
        public StatName MainStat { get; set; }
        public List<Skill> Skills { get; set; }
    }

    public enum StatName { Strength, Stamina, Wisdom, Agility, Intelligence }
}
