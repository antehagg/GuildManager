using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GuildManager.Data.GameData.Classes;
using GuildManager.Data.GameObjects.Characters.Stats;

namespace GuildManager.Data.GameData.Characters
{
    public class DbPlayerCharacter : DbCharacter
    {
        public DbEquipedItems EquipedItems { get; set; }
    }
}
