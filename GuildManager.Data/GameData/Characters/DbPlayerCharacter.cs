using System.ComponentModel.DataAnnotations.Schema;
using GuildManager.Data.GameData.Classes;
using GuildManager.Data.GameObjects.Characters.Stats;

namespace GuildManager.Data.GameData.Characters
{
    public class DbPlayerCharacter : DbCharacter
    {
        public int EquipedItemsId { get; set; }
        public DbEquipedItems EquipedItems { get; set; }
    }
}
