using GuildManager.Data.GameData.Classes;

namespace GuildManager.Data.GameData.Characters
{
    public class DbCharacter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DbGameClass Class { get; set; }
        public DbInventory Inventory { get; set; }
    }
}
