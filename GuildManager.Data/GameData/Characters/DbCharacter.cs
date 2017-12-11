using GuildManager.Data.GameData.Classes;

namespace GuildManager.Data.GameData.Characters
{
    public class DbCharacter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClassId { get; set; }
        public DbGamelass Class { get; set; }
        public int InventoryId { get; set; }
        public DbInventory Inventory { get; set; }
    }
}
