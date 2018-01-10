using GuildManager.Data.GameData.Items;

namespace GuildManager.Data.GameData.Characters.CharactersData
{
    public class PossibleLoot
    {
        public int Id { get; set; }
        public DbItem Item { get; set; }
        public double Chance { get; set; }
    }
}
