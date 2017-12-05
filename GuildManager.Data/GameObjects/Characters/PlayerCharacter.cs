using GuildManager.Data.GameObjects.Classes;
using GuildManager.Data.GameObjects.Races;
using GuildManager.Data.GameObjects.Stats;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuildManager.Data.GameObjects.Characters
{
    public class PlayerCharacter : Character
    {
        public string Name { get; set; }
        public GameClass Class { get; set; }
        public Race Race { get; set; }
        public PlayerStats Stats { get; set; }
        public Inventory Inventory { get; set; }
        public EquipedItems EquipedItems { get; set; }
    }
}
