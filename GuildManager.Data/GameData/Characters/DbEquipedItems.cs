using System.Collections.Generic;
using GuildManager.Data.GameData.Items;
using GuildManager.Data.GameData.Items.Types;

namespace GuildManager.Data.GameData.Characters
{
    public class DbEquipedItems
    {
        public int Id { get; set; }
        public int MainHandId { get; set; }
        public DbItem MainHand { get; set; }
    }
}