using GuildManager.Data.GameData.Characters;
using GuildManager.Data.GameData.Classes;
using GuildManager.Data.GameData.Classes.GameClassData;
using GuildManager.Data.GameObjects.Characters.Stats;
using GuildManager.Data.GameObjects.Characters.Stats.SpecificStat;

namespace GuildManager.Data.GameObjects.Characters
{
    public class Monster : ICharacter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DbGameClass Class { get; set; }
        public Resource Health { get; set; }
        public Resource Energy { get; set; }
        public BaseResources MonsterBaseResources { get; set; }
        public EquippedItems EquippedItems { get; set; }
        public PlayerStats Stats { get; set; }

        public Monster(DbMonster monsterInfo)
        {
            MonsterBaseResources = monsterInfo.MonsterBaseResources;
            EquippedItems = null;
            Id = monsterInfo.Id;
            Name = monsterInfo.Name;
            Class = monsterInfo.Class;
            CalculateResource();
        }

        public void ChangeCurrentHealth(int change)
        {
            Health.CurrentValue += change;
        }

        public int GetCurrentHealth()
        {
            return Health.CurrentValue;
        }

        public void CalculateResource()
        {
            Health = new Health(Class.BaseResources.BaseHealth, 0, 0, 0);
            Energy = new Energy(100, 50, 0, 0);
        }


    }

}
