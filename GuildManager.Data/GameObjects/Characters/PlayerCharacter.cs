using System;
using System.Collections.Generic;
using System.Text;
using GuildManager.Data.GameData.Characters;
using GuildManager.Data.GameData.Classes;
using GuildManager.Data.GameData.Classes.GameClassData;
using GuildManager.Data.GameObjects.Characters.Stats;

namespace GuildManager.Data.GameObjects.Characters
{
    public class PlayerCharacter : Character
    {
        public EquippedItems EquippedItems { get; set; }

        public PlayerStats Stats { get; set; }

        public PlayerCharacter(DbPlayerCharacter playerInfo)
        {
            Id = playerInfo.Id;
            Name = playerInfo.Name;
            Class = playerInfo.Class;
            EquippedItems = new EquippedItems(playerInfo.EquipedItems);
            CalculateStats();
        }

        private void CalculateStats()
        {
            Stats = new PlayerStats(Class.BaseStats, Class.BaseResources, Class.MainStat, EquippedItems.TotalStats);
        }
    }

}
