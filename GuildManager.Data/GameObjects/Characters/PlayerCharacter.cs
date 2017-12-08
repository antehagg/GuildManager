using GuildManager.Data.GameObjects.Classes;
using GuildManager.Data.GameObjects.Races;
using GuildManager.Data.GameObjects.Stats;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GuildManager.Data.GameObjects.Characters
{
    public class PlayerCharacter : Character
    {
        public string Name { get; set; }
        public int ClassId { get; set; }
        private GameClass _class;
        public GameClass Class
        {
            get => _class;
            set { _class = value; CalculateStats(); }
        }

        public Race Race { get; set; }
        public Inventory Inventory { get; set; }
        public EquipedItems EquipedItems { get; set; }

        #region NotMapped
        [NotMapped]
        public PlayerStats Stats { get; set; }
        #endregion

        private void CalculateStats()
        {
            Stats = new PlayerStats(Class.BaseStrength, Class.BaseHealth);
        }
    }
}
