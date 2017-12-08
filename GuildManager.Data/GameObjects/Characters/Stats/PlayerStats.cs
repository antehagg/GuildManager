using GuildManager.Data.GameData.Classes.GameClassData;

namespace GuildManager.Data.GameObjects.Characters.Stats
{
    public class PlayerStats
    {
        public Stat Strength { get; set; }
        public Stat Stamina { get; set; }
        public Stat Agility { get; set; }
        public Stat Wisdom { get; set; }
        public Stat Intelligence { get; set; }
        public Resource Health { get; set; }

        public PlayerStats(BaseStats baseStats, BaseResources baseResources)
        {
            CalculateStats(baseStats);
            CalculateResources(baseResources);
        }

        private void CalculateStats(BaseStats basestats)
        {
            Strength = new Stat(basestats.BaseStrength, 0, 0);
            Agility = new Stat(basestats.BaseAgility, 0, 0);
            Stamina = new Stat(basestats.BaseStamina, 0, 0);
            Wisdom = new Stat(basestats.BaseWisdom, 0, 0);
            Intelligence = new Stat(basestats.BaseIntelligence, 0, 0);
        }

        private void CalculateResources(BaseResources baseResources)
        {
            Health = new Resource(baseResources.BaseHealth, 0, 0, Stamina.MaxValue);
        }
    }
}
