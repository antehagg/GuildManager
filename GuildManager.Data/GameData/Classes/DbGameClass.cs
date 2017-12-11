﻿using System;
using System.Dynamic;
using GuildManager.Data.GameData.Classes.GameClassData;

namespace GuildManager.Data.GameData.Classes
{
    public class DbGameClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BaseStats BaseStats { get; set; }
        public BaseResources BaseResources { get; set; }
        public StatName MainStat { get; set; }
    }

    public enum StatName { Strength, Stamina, Wisdom, Agility, Intelligence }
}