using System;
using System.Collections.Generic;
using System.Text;
using GuildManager.Data.GameData.Characters;
using GuildManager.Data.GameData.Classes;
using GuildManager.Data.GameData.Classes.GameClassData;
using GuildManager.Data.GameObjects.Characters.Stats;

namespace GuildManager.Data.GameObjects.Characters
{
    public class Player : Character
    {
        public EquippedItems EquippedItems { get; set; }

        public PlayerStats Stats { get; set; }

        public Player(int id, string name, DbGameClass dbGameClass, EquippedItems equippedItems, PlayerStats stats)
        {
            Id = id;
            Name = name;
            Class = dbGameClass;
            EquippedItems = equippedItems;
            Stats = stats;
        }

        public Player(DbPlayerCharacter playerInfo)
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
