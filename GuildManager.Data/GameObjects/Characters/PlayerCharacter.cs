using System;
using System.Collections.Generic;
using System.Text;
using GuildManager.Data.GameData.Characters;
using GuildManager.Data.GameData.Classes;
using GuildManager.Data.GameData.Classes.GameClassData;
using GuildManager.Data.GameData.Races;
using GuildManager.Data.GameObjects.Characters.Stats;

namespace GuildManager.Data.GameObjects.Characters
{
    public class PlayerCharacter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DbGamelass Class { get; set; }
        public EquippedItems EquippedItems { get; set; }

        public PlayerStats Stats { get; set; }

        public PlayerCharacter(DbPlayerCharacter playerInfo)
        {
            Id = playerInfo.Id;
            Name = playerInfo.Name;
            Class = playerInfo.Class;
            CalculateStats();
        }

        private void CalculateStats()
        {
            Stats = new PlayerStats(Class.BaseStats, Class.BaseResources, Class.MainStat, EquippedItems.TotalStats);
        }
    }

}
