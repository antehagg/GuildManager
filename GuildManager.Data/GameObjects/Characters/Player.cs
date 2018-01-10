using GuildManager.Data.GameData.Characters;
using GuildManager.Data.GameData.Classes;
using GuildManager.Data.GameObjects.Characters.Stats;

namespace GuildManager.Data.GameObjects.Characters
{
    public class Player : ICharacter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DbGameClass Class { get; set; }
        public EquippedItems EquippedItems { get; set; }

        public PlayerStats Stats { get; set; }

        public Player(int id, string name, DbGameClass dbGameClass, EquippedItems equippedItems, PlayerStats stats)
        {
            Id = id;
            Name = name;
            Class = dbGameClass;
            EquippedItems = equippedItems;
            Stats = stats;
        }

        public Player(DbPlayerCharacter playerInfo)
        {
            Id = playerInfo.Id;
            Name = playerInfo.Name;
            Class = playerInfo.Class;
            EquippedItems = new EquippedItems(playerInfo.EquipedItems);
            CalculateStats();
        }

        public int GetCurrentHealth()
        {
            return Stats.Health.CurrentValue;
        }

        public void ChangeCurrentHealth(int change)
        {
            Stats.Health.CurrentValue += change;
        }

        private void CalculateStats()
        {
            Stats = new PlayerStats(Class.BaseStats, Class.BaseResources, Class.MainStat, EquippedItems.TotalStats);
        }
    }
}
