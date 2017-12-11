using System;
using System.Collections.Generic;
using System.Text;
using GuildManager.Data.GameData.Items.ItemsData;
using GuildManager.Data.GameData.Items.Types;

namespace GuildManager.Data.GameData.Items
{
    public class DbItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StatsId { get; set; }
        public  ItemStats Stats { get; set; }
        public ItemRarity ItemRarity { get; set; }
    }
}
