using System.ComponentModel.DataAnnotations.Schema;
using GuildManager.Data.GameData.Classes;
using GuildManager.Data.GameData.Races;
using GuildManager.Data.GameObjects.Characters.Stats;

namespace GuildManager.Data.GameData.Characters
{
    public class DbPlayerCharacter : DbCharacter
    {
        public string Name { get; set; }
        public int ClassId { get; set; }
        public DbGamelass Class { get; set; }

        public DbRace Race { get; set; }
        public DbInventory Inventory { get; set; }
        public int EquipedItemsId { get; set; }
        public DbEquipedItems EquipedItems { get; set; }
    }
}
