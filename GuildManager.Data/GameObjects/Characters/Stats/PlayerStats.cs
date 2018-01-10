using GuildManager.Data.GameData.Classes;
using GuildManager.Data.GameData.Classes.GameClassData;
using GuildManager.Data.GameData.Items.ItemsData;
using GuildManager.Data.GameObjects.Characters.Stats.SpecificStat;

namespace GuildManager.Data.GameObjects.Characters.Stats
{
    public class PlayerStats
    {
        public int Strength { get; set; }
        public int Stamina { get; set; }
        public int Agility { get; set; }
        public int Wisdom { get; set; }
        public int Intelligence { get; set; }

        public double Haste { get; set; }
        public double CritChance { get; set; }

        public Resource Health { get; set; }
        public Resource Energy { get; set; }

        public PlayerStats(BaseStats baseStats, BaseResources baseResources, StatName mainStat, ItemStats itemStats)
        {
            CalculateStats(baseStats, itemStats);
            CalculateResources(baseResources, mainStat, itemStats);
        }

        public void BuffStats(BuffStats buffStats)
        {
            Health.MaxValue += buffStats.Health;
            Health.CurrentValue += buffStats.Health;
        }

        public void RemoveBuffStats(BuffStats buffStats)
        {
            Health.MaxValue -= buffStats.Health;
            Health.CurrentValue -= buffStats.Health;
        }

        private void CalculateStats(BaseStats baseStats, ItemStats itemStats)
        {
            Strength = baseStats.BaseStrength + itemStats.Strength;
            Stamina = baseStats.BaseStamina + itemStats.Stamina;
            Agility = baseStats.BaseAgility + itemStats.Agility;
            Wisdom = baseStats.BaseWisdom + itemStats.Wisdom;
            Intelligence = baseStats.BaseIntelligence + itemStats.Intelligence;

            Haste = itemStats.Haste;
            CritChance = 10 + itemStats.CritChance;
        }

        private void CalculateResources(BaseResources baseResources, StatName mainStat, ItemStats itemStats)
        {
            Health = new Health(baseResources.BaseHealth, itemStats.Health, 0, Stamina);
            if(mainStat == StatName.Agility)
                Energy = new Energy(100, itemStats.Agility , 0 , Agility);
            if (mainStat == StatName.Strength)
                Energy = new Energy(100, itemStats.Strength, 0, Strength);
            if (mainStat == StatName.Wisdom)
                Energy = new Energy(100, itemStats.Wisdom, 0, Wisdom);
            if (mainStat == StatName.Intelligence)
                Energy = new Energy(100, itemStats.Intelligence, 0, Intelligence);
        }
    }
}
